using Windows.UI.Xaml.Controls;
using CityMap.Services;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace CityMap.Views
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CitiesView : Page
	{
		public CitiesView()
		{
			this.InitializeComponent();

			var citiesService = new CitiesService();
			CitiesListView.ItemsSource = citiesService.Cities;
		}

		private void CitiesListView_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frame.Navigate(typeof(CityDetailsView), e.ClickedItem);
		}
	}
}
