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
		private const string NoConnectionLabel = "No internet connection!";
		private const string NoDataLabel = "No data!";

		private CitiesService _citiesService;
		private NetworkService _networkService;

		public CitiesView()
		{
			this.InitializeComponent();

			_citiesService = new CitiesService();
			_networkService = new NetworkService();
		}

		private async void Page_Loaded(object sender, RoutedEventArgs e)
		{
			await InitializeAsync();
		}

		/// <summary>
		/// Initialize view
		/// </summary>
		/// <returns></returns>
		private async Task InitializeAsync()
		{
			LoadingProgressRing.IsActive = true;

			var cities = await _citiesService.LoadCitiesAsync();

			LoadingProgressRing.IsActive = false;

			if (cities == null)
			{
				ShowNoDataTextBlock();
			}
			else
			{
				CitiesGridView.ItemsSource = cities;
			}
		}

		/// <summary>
		/// Change data availability text block and set visibility to visible
		/// </summary>
		private void ShowNoDataTextBlock()
		{
			NoDataTextBlock.Text = _networkService.HasInternet() ? NoDataLabel : NoConnectionLabel;
			NoDataTextBlock.Visibility = Visibility.Visible;
		}

		private void CitiesGridView_ItemClick(object sender, ItemClickEventArgs e)
		{
			Frame.Navigate(typeof(CityDetailsView), e.ClickedItem);
		}
	}
}
