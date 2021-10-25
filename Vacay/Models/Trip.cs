namespace Vacay.Models
{
  public class Trip : DbItem
  {
      public int Price { get; set; }
      public string Destination { get; set; }
      public string CreatorId {get; set;}
  }
}