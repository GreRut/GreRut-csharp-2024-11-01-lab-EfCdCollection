using System.ComponentModel.DataAnnotations;

namespace CdApi.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CD> CDList {get; set; } = [];
    }
}