namespace Keepr.Models
{
  public class Item
  {
    public Item()
    { }
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Img { get; set; }
    public bool IsPrivate { get; set; }

  }
}