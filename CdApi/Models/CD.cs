namespace CdApi.Models
{
    public class CD
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ArtistName { get; set; }
        public string Description { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}