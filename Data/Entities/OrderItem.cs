namespace DutchTreat.Data.Entities
{
  public class OrderItem
  {
    public int Id { get; set; }
    public Product Product { get; set; } //relationship between product and the order it belongs to
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Order Order { get; set; } //relationship between product and the order it belongs to
	}
}