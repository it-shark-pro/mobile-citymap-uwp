using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CityMap.Models;

namespace CityMap.Infrastructure
{
	public class LocalSettingsStorage
	{
		private const string ApplicationDataFileName = "applicationData.txt";

		private Windows.Storage.StorageFolder _localFolder;

		public LocalSettingsStorage()
		{
			_localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
		}

		/// <summary>
		/// Serialize and save application data object to file in application data local folder
		/// </summary>
		/// <param name="data">The application data object</param>
		/// <returns></returns>
		public async Task SaveApplicationData(ApplicationData data)
		{
			var dataFile = await _localFolder.CreateFileAsync(ApplicationDataFileName, Windows.Storage.CreationCollisionOption.ReplaceExisting);
			await Windows.Storage.FileIO.WriteTextAsync(dataFile, JsonConvert.SerializeObject(data));
		}

		/// <summary>
		/// Read and deserialize application data
		/// </summary>
		/// <returns>Returns application </returns>
		public async Task<ApplicationData> GetApplicationData()
		{
			try
			{
				var dataFile = await _localFolder.GetFileAsync(ApplicationDataFileName);
				var savedData = await Windows.Storage.FileIO.ReadTextAsync(dataFile);

				return JsonConvert.DeserializeObject<ApplicationData>(savedData);
			}
			catch (Exception)
			{
				return new ApplicationData();
			}
		}
	}
}
