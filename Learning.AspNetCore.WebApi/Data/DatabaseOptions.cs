using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Learning.AspNetCore.WebApi.Data
{
    public class DatabaseOptions
    {
        public DatabaseOptionsProvider Provider { get; set; }

        public string ConnectionString { get; set; }
    }
}