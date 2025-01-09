using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CdApi.Models
{
    public class CDwithGenre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? GenreId { get; set; }
        public string GenreName { get; set;}
    }
}