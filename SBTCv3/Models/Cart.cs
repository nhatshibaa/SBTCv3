namespace SBTCv3.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string IdentityCard { get; set; }
        public int idTicket { get; set; }
        public int Quantity { get; set; }
        public string createTime { get; set; }
        public DateTime exprired { get; set; }
    }
}
