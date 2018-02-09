using Windows.Networking.Connectivity;

namespace CityMap.Services
{
	public class NetworkService
	{
		/// <summary>
		/// Check connection availability
		/// </summary>
		/// <returns>Returns true in case we have internet access</returns>
		public bool HasInternet()
		{
			var connectionProfile = NetworkInformation.GetInternetConnectionProfile();
			return connectionProfile != null && connectionProfile.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess;
		}
	}
}
