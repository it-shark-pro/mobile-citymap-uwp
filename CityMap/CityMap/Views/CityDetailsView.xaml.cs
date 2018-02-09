using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Media.Imaging;
using CityMap.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CityMap.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CityDetailsView : Page
	{
		public CityDetailsView()
		{
			this.InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			var city = e.Parameter as City;

			if (city != null)
			{
				CityImage.Source = new BitmapImage(new Uri(city.ImageUrl));
				NameTextBlock.Text = city.Name;
				DescriptionTextBlock.Text = city.Description;
			}

			base.OnNavigatedTo(e);
		}
	}
}
