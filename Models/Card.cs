namespace ATM.Models
{
  public class Card
  {
    public Card()
    { }
    public int Id { get; set; }
    public string UserId { get; set; }
    public string CardHolder { get; set; }
    public string Bank { get; set; }
    public string CardImg { get; set; }
    public int Pin { get; set; }
    public string ExpirationDate { get; set; }
    public int CVV { get; set; }
  }
}