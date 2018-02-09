using System.Collections.Generic;
using Windows.Devices.Geolocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Navigation;
using CityMap.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CityMap.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CitiesMapsView : Page
	{
		public CitiesMapsView()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var cities = e.Parameter as IEnumerable<City>;

			if (cities != null)
			{
				foreach (var city in cities)
				{
					AddMapIcon(city);
				}
			}

			base.OnNavigatedTo(e);
		}

		/// <summary>
		/// Add map icon to map control
		/// </summary>
		/// <param name="city">The city</param>
		private void AddMapIcon(City city)
		{
			var location = new BasicGeoposition();
			var mapIcon = new MapIcon();

			location.Latitude = city.Latitude;
			location.Longitude = city.Longitude;

			if (mapIcon != null)
			{
				CitiesMapControl.MapElements.Remove(mapIcon);
			}

			mapIcon.Location = new Geopoint(location);
			mapIcon.Title = city.Name;

			CitiesMapControl.MapElements.Add(mapIcon);
			CitiesMapControl.Center = new Geopoint(location);
		}
	}
}
