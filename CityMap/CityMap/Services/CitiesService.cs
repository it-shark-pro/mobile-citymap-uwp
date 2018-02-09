using System.Collections.Generic;
using System.Threading.Tasks;
using CityMap.Models;
using CityMap.Services.Api;
using CityMap.Infrastructure;

namespace CityMap.Services
{
	public class CitiesService
	{
		private readonly ApplicationApiService _applicationApiService;
		private LocalSettingsStorage _localSettingsStorage;

		public CitiesService()
		{
			_applicationApiService = new ApplicationApiService();
			_localSettingsStorage = new LocalSettingsStorage();
		}

		/// <summary>
		/// Load cities collection
		/// </summary>
		/// <returns>Returns cities collection</returns>
		public async Task<IEnumerable<City>> LoadCitiesAsync()
		{
			var applicationData = await _applicationApiService.FetchDataAsync();

			if (applicationData.Cities != null)
			{
				await _localSettingsStorage.SaveApplicationData(applicationData);
			}
			else
			{
				applicationData = await _localSettingsStorage.GetApplicationData();
			}

			return applicationData.Cities;
		}
	}
}
