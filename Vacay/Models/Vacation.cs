namespace Vacay.Models
{
  public class Vacation : DbItem
    {
        public float Price { get; set; }
        public string Destination { get; set; }
        public string CreatorId{get; set;}
    }
}