namespace AMP.Web.Models.PageDtos
{
    public class CustomerPageDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public UserPageDto User { get; set; }
    }
}