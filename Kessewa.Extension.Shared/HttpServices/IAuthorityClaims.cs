using System.Net.Http;
using System.Threading.Tasks;

namespace Qface.Extension.Shared.HttpServices
{
	public class IAuthorityClaims
	{
		// TODO:: Customize to suit Identity server token claims
		public string Sub { get; set; }
		public string Website { get; set; }
		public string FamilyName { get; set; }
		public string GivenName { get; set; }
		public string Name { get; set; }
		public string PreferredUsername { get; set; }
		public string Token {  get; set; }

	}
}
