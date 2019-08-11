using SampleApi.Data;
using SampleApi.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleApi.Service.Todo
{
    public class TodoService
    {
        /// <summary>
        /// 若不填Id則取全部, 填了取部分
        /// </summary>
        /// <param name="db"></param>
        /// <param name="Ids"></param>
        /// <returns></returns>
        private IQueryable<TodoItem> Get(TodoContext db, params Guid[] Ids)
        {
            var query = db.TodoItems.AsQueryable();
            if (Ids.Count() > 0)
            {
                query = query.Where(item => Ids.Contains(item.Id));
            }
            return query;
        }
        public bool IsExist(Guid Id)
        {
            if (Id == null || Id == Guid.Empty)
                return false;

            using (TodoContext db = new TodoContext())
            {
                return Get(db, Id).Count() > 0;
            }
        }

        public IEnumerable<TodoItem> Remove(params Guid[] Ids)
        {
            List<TodoItem> removedItems = new List<TodoItem>();
            if (Ids.Count() == 0)
                return removedItems;
            try
            {
                using (TodoContext db = new TodoContext())
                {
                    var exists = Get(db, Ids).ToList();
                    foreach (var Id in Ids)
                    {
                        var exist = exists.FirstOrDefault(item => item.Id.Equals(Id));
                        if (exist != null)
                        {
                            removedItems.Add(exist);
                            var entry = db.Entry(exist);
                            entry.State = System.Data.Entity.EntityState.Deleted;
                        }
                    }
                    db.SaveChanges();
                }
            }
            catch
            {

                throw;
            }
            return removedItems;
        }
        public IEnumerable<TodoItem> Save(params TodoItem[] items)
        {
            try
            {
                var _items = SetItems(items);
                var existIds = _items.Select(item => item.Id).ToList();
                using (TodoContext db = new TodoContext())
                {
                    var exists = Get(db, existIds.ToArray()).ToList();
                    foreach (var item in _items)
                    {
                        var exit = exists.FirstOrDefault(e => e.Id.Equals(item.Id));
                        if (exit == null)
                        {
                            db.TodoItems.Add(item);
                        }
                        else
                        {
                            var entry = db.Entry(exit);
                            entry.State = System.Data.Entity.EntityState.Modified;
                            entry.CurrentValues.SetValues(item);
                        }
                    }
                    db.SaveChanges();
                }
                return _items;
            }
            catch
            {

                throw;
            }
        }

        public IEnumerable<TodoItem> Get(params Guid[] Ids)
        {
            try
            {
                using (TodoContext db = new TodoContext())
                {
                    return Get(db, Ids).ToList();
                }
            }
            catch
            {
                throw;
            }
        }

        private IEnumerable<TodoItem> SetItems(params TodoItem[] items)
        {
            foreach (var item in items)
            {
                item.Id = item.Id == Guid.Empty ? Guid.NewGuid() : item.Id;
                yield return item;
            }
        }
    }
}
