namespace AMP.Web.Models.Stores.Artisan
{
    public class ResetArtisanAction : IAction
    {
        public const string RESET = "RESET";

        // Type
        public string NameOfAction => RESET;

        // Optional payload
        //public ArtisanDto Artisan { get; set; }

    }
}
