using System.Collections.Generic;
using System.Threading.Tasks;
using CityMap.Models;
using CityMap.Services.Api;

namespace CityMap.Services
{
	public class CitiesService
	{
		private readonly ApplicationApiService _applicationApiService;

		public CitiesService()
		{
			_applicationApiService = new ApplicationApiService();
		}

		/// <summary>
		/// Load cities collection
		/// </summary>
		/// <returns>Returns cities collection</returns>
		public async Task<IEnumerable<City>> LoadCitiesAsync()
		{
			var applicationData = await _applicationApiService.FetchDataAsync();
			return applicationData.Cities;
		}
	}
}
