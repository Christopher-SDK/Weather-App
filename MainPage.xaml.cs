namespace WeatherApp;

public partial class MainPage : ContentPage
{
	Service service; 

	public MainPage()
	{
		InitializeComponent();
		service = new Service();
	}

	async void GetWeatherBtnClicked(object sender, EventArgs e)
	{
		if (!string.IsNullOrWhiteSpace(cityEntry.Text))
		{
			Data data = await service.GetData(GenerateUrlRequest(Constants.OpenWeatherMapLink));
			BindingContext = data;
		}
	}

	string GenerateUrlRequest(string endpoint)
	{
		string urlRequest = endpoint;
		urlRequest += $"?q={cityEntry.Text}";
		urlRequest += "&units=imperial";
		urlRequest += $"&APPID={Constants.OpenWeatherMapKey}";
		return urlRequest;
	}
}

