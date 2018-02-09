using System.Threading.Tasks;
using Windows.UI.Xaml;
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
		private CitiesService _citiesService;

		public CitiesView()
		{
			this.InitializeComponent();

			_citiesService = new CitiesService();
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			await InitializeAsync();
		}

		private async Task InitializeAsync()
		{
			LoadingProgressRing.IsActive = true;

			CitiesGridView.ItemsSource = await _citiesService.LoadCitiesAsync();

			LoadingProgressRing.IsActive = false;
		}

		private void CitiesGridView_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frame.Navigate(typeof(CityDetailsView), e.ClickedItem);
		}
	}
}
