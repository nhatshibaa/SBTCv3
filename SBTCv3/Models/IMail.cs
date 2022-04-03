namespace SBTCv3.Models
{
    public interface IMail
    {
        string username { get; set; }
        string email { get; set; }
        string identityCard { get; set; }
        int idTicket { get; set; }
        int quantity { get; set; }
        string createTime { get; set; }
        DateTime exprired { get; set; }
    }
}