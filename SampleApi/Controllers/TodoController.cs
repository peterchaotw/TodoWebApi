using SampleApi.Data.Model;
using SampleApi.Models;
using SampleApi.Service.Todo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SampleApi.Controllers
{
    public class TodoController : ApiController
    {
        private TodoService service
        {
            get
            {
                if (_service == null)
                {
                    _service = new TodoService();
                }
                return _service;
            }
        }
        private TodoService _service { get; set; }
        public ApiResponse<TodoItem> Get()
        {
            return _Get();
        }

        private ApiResponse<TodoItem> _Get(params Guid[] Ids)
        {
            var response = new ApiResponse<TodoItem>();
            try
            {
                if (Ids != null)
                {
                    var data = service.Get(Ids);
                    response.Data = data;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "Id is null";
                    response.IsSuccess = false;

                }
            }
            catch (Exception ex)
            {
                response.Message = "Error occurred";
                response.IsSuccess = false;
            }
            return response;
        }

        // GET: api/Todo/5
        public ApiResponse<TodoItem> Get(Guid id)
        {
            return _Get(id);
        }

        // POST: api/Todo
        public ApiResponse<TodoItem> Post([FromBody]TodoItem[] values)
        {
            var response = new ApiResponse<TodoItem>();
            try
            {
                if (values != null)
                {
                    var data = service.Save(values);
                    response.Data = data;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "data is null";
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error occurred";
                response.IsSuccess = false;
            }
            return response;
        }

        // PUT: api/Todo/5
        public ApiResponse<TodoItem> Put([FromBody]TodoItem value)
        {
            var response = new ApiResponse<TodoItem>();
            try
            {
                if (value != null)
                {
                    var data = service.Save(value);
                    response.Data = data;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "data is null";
                    response.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error occurred";
                response.IsSuccess = false;
            }
            return response;
        }

        // DELETE: api/Todo/5
        public ApiResponse<TodoItem> Delete(Guid Id)
        {
            var response = new ApiResponse<TodoItem>();
            try
            {
                if (service.IsExist(Id))
                {
                    var data = service.Remove(Id);
                    response.Data = data;
                    response.IsSuccess = true;
                }
                else
                {
                    response.IsSuccess = true;
                    response.Message = "Data is not exist.";
                }
            }
            catch (Exception ex)
            {
                response.Message = "Error occurred";
                response.IsSuccess = false;
            }
            return response;
        }
    }
}
