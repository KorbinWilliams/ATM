namespace ATM.models
{
  public class CardCash
  {
    public CardCash()
    { }
    public int Id { get; set; }
    public int CardId { get; set; }
    public int Cash { get; set; }
    public string UserId { get; set; }
  }
}