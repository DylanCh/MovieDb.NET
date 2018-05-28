using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieDb.NET.Models{
    public class Movie{
        public string Description {get;set;}
        public string Original_Title {get;set;}
        public string Title {get;set;}

    }
}