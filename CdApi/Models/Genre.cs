using System.ComponentModel.DataAnnotations;

namespace CdApi.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CD> CDList {get; set; } = [];
    }
}