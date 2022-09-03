namespace AMP.Web.Models.Stores.Customer
{
    public class ResetCustomerAction : IAction
    {
        public const string RESET = "RESETCUSTOMER";

        // Type
        public string NameOfAction => RESET;
    }
}
