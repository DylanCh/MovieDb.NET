using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using MovieDb.NET.Models;

namespace MovieDb.NET.DataLayer{
    public class DataProvider: DbContext{
        private const string dbName = "";
        private const string userName = "";
        private const string pword = "";
        private NpgsqlConnection connection;

        private string connectionString = $"Host=localhost;Username={userName};Password={pword};Database={dbName}";
        public IList<Movie> GetMovie(string title = null){
            using ( connection = new NpgsqlConnection(connectionString)){
                if(connection.State == ConnectionState.Closed)
                    connection.Open();
                using (var cmd = new NpgsqlCommand{ Connection = connection}){
                    cmd.CommandText = "Select * from movies ";
                    if(!string.IsNullOrEmpty(title))
                        cmd.CommandText+= $" where upper(title) like '%{title.ToUpper()}%'";
                    var movieList = new List<Movie>();
                    using(var reader = cmd.ExecuteReader()){
                        if(!reader.HasRows)
                            return movieList;
                        else {
                            while (reader.Read()){
                                var movie = new Movie{
                                    Title = reader["title"].ToString(),
                                    Description = reader["Description"].ToString(),
                                    Original_Title = reader["Original_Title"].ToString()
                                };
                                movieList.Add(movie);
                            }
                            return movieList;
                        }
                    }
                }
            }
        }

    }
}