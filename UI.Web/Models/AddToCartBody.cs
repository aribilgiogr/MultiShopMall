namespace UI.Web.Models
{
    public class AddToCartBody
    {
        public string Username { get; set; }
        public int ProductId { get; set; }
    }

    public class ChangeQuantityBody
    {
        public string Username { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
