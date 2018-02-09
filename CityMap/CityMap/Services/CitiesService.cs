using System.Collections.Generic;
using System.Threading.Tasks;
using CityMap.Models;
using CityMap.Services.Api;

namespace CityMap.Services
{
	public class CitiesService
	{
		private readonly ApplicationApiService _applicationApiService;

		public IEnumerable<City> Cities => new[]
		{
			new City
			{
				Name = "Minsk",
				Description = "Minsk is the capital of Belarus"
			},
			new City
			{
				Name = "Warsaw",
				Description = "Warsaw is the capital of Poland"
			},
			new City
			{
				Name = "Berlin",
				Description = "Berlin is the capital of Germany"
			},
			new City
			{
				Name = "Amsterdam",
				Description = "Amsterdam is the capital of Netherland"
			},
			new City
			{
				Name = "Oslo",
				Description = "Oslo is the capital of Norway"
			},
			new City
			{
				Name = "Lisbon",
				Description = "Lisbon is the capital of Portugal"
			},
			new City
			{
				Name = "Madrid",
				Description = "Madrid is the capital of Spain"
			},
			new City
			{
				Name = "Moskow",
				Description = "Moskow is the capital of Russia"
			},
			new City
			{
				Name = "Kiev",
				Description = "Kiev is the capital of Ukraine"
			},
			new City
			{
				Name = "Stockholm",
				Description = "Stockholm is the capital of Sweden"
			}
		};

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
