using System;
using BlazorDemo.Areas.Identity.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BlazorDemo.Data
{
    public class BlazorDemoIdentityServices
    {
        public async Task<List<MyData>> GetDataFromSQLiteAsync()
        {
            using (var connection = new SqliteConnection("Data Source=app.db"))
            {
                connection.Open();
                var query = "SELECT UserName, Email, Administrator FROM AspNetUsers";
                var data = await connection.QueryAsync<MyData>(query);
                return data.ToList();
            }
        }
        public async Task<int> GetAdministratorAsync(string userName)
        {
            using (var connection = new SqliteConnection("Data Source=app.db"))
            {
                connection.Open();
                var query = "SELECT Administrator FROM AspNetUsers WHERE UserName = @userName";
                var data = await connection.QuerySingleOrDefaultAsync<int?>(query, new { userName });
                return data.HasValue ? data.Value : 0;
            }
        }

    }

    public class MyData
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int Administrator { get; set; }
        public string? LoginName { get; set; }
    }
}
