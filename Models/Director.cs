using System.ComponentModel.DataAnnotations;

namespace MovieDb.NET.Models{
    public class Director{
        public long Id {get;set;}
        public string Name {get;set;}
        public string Imdb {get;set;}
        public string Title {get;set;}
    }
}