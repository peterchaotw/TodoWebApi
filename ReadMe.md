# DataBase Initialize
Refer:https://docs.microsoft.com/zh-tw/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application
`
enable-migrations -ContextTypeName SampleApi.Data.TodoContext -MigrationsDirectory:TodoMigrations
Add-Migration -configuration SampleApi.Data.TodoMigrations.Configuration init
Update-Database -configuration SampleApi.Data.TodoMigrations.Configuration -Verbose
Update-Database -configuration SampleApi.Data.TodoMigrations.Configuration -Verbose -script
`