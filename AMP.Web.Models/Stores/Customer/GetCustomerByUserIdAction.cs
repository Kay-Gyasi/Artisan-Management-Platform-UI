namespace AMP.Web.Models.Stores.Customer
{
    public class GetCustomerByUserIdAction : IAction
    {
        public const string GETBYUSERID = "GETCUSTOMERBYUSERID";

        // Type
        public string NameOfAction => GETBYUSERID;
    }
}
