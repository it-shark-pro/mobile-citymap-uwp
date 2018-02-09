using System;
using System.Threading.Tasks;
using Windows.Web.Http;
using Newtonsoft.Json;
using CityMap.Models;

namespace CityMap.Services.Api
{
	public class ApplicationApiService
	{
		private const string ApplicationDataUrl = "https://api.myjson.com/bins/7ybe5";

		/// <summary>
		/// Fetch data from remote service
		/// </summary>
		/// <returns>Returns deserialized application data object</returns>
		public async Task<ApplicationData> FetchDataAsync()
		{
			var httpClient = new HttpClient();
			var applicationDataUri = new Uri(ApplicationDataUrl);
			var result = new ApplicationData();

			try
			{
				var response = await httpClient.GetStringAsync(applicationDataUri);
				result = JsonConvert.DeserializeObject<ApplicationData>(response);
			}
			catch
			{
				// Details in ex.Message and ex.HResult.
			}

			httpClient.Dispose();

			return result;
		}
	}
}
