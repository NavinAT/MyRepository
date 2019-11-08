using Microsoft.VisualStudio.TestTools.UnitTesting;
using MutualFundAPI;

namespace MutualFundAPITest
{
	[TestClass]
	public class NavMutualFundTest
	{
		#region Tests
		[TestMethod]
		public void TestGetMutualFundNav()
		{
			// Arrange
			LufthansaAccessToken accessToken = new LufthansaAccessToken
			                                   {
				                                   ClientId = "r2gzamvxt7x24c595vb5ww24",
				                                   ClientSecret = "rGJqxEZCW4",
				                                   GrantType = "client_credentials"
			                                   };

			// Act
			ResponseFromLufthansa responseFromLufthansa = NavMutualFund.GetAccessToken(accessToken).GetAwaiter().GetResult();

			// Assert
		}
		#endregion
	}
}