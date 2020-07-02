namespace ATM.Models
{
  public class CardCash
  {
    public CardCash()
    { }
    public int Id { get; set; }
    public int CardId { get; set; }
    public int CashId { get; set; }
    public string UserId { get; set; }
  }
}