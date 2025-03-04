namespace TeaManagmentSystem2.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int TeaId { get; set; }
        public Tea Tea { get; set; }
        public int Quantity { get; set; }
    }
}
