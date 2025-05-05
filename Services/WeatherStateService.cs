using System.Net.Http.Json;
using WeatherApp1.Models;

namespace WeatherApp1.Services
{
    /// <summary>
    /// Service for managing shared state of weather and user data across components
    /// </summary>
    public class WeatherStateService
    {
        private readonly HttpClient _httpClient;
        private readonly string _weatherApiKey = "d3b7015912d64c82af9100400250105";
        
        // State storage
        public WeatherResponse? WeatherData { get; private set; }
        public List<User>? UserData { get; private set; }
        
        // Loading state flags
        public bool IsLoadingWeather { get; private set; }
        public bool IsLoadingUsers { get; private set; }
        
        // Error messages
        public string? WeatherErrorMessage { get; private set; }
        public string? UsersErrorMessage { get; private set; }
        
        // State change notifications
        public event Action? OnChange;
        
        // Current location for weather data
        public string CurrentLocation { get; private set; } = "London";
        
        // Cancellation token sources for API requests
        private CancellationTokenSource? _weatherCts;
        private CancellationTokenSource? _usersCts;
        
        public WeatherStateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        /// <summary>
        /// Notifies all subscribers that the state has changed
        /// </summary>
        private void NotifyStateChanged()
        {
            OnChange?.Invoke();
        }
        
        /// <summary>
        /// Sets the current location and fetches weather data for that location
        /// </summary>
        public async Task SetLocationAsync(string location)
        {
            if (string.IsNullOrWhiteSpace(location)) return;
            
            CurrentLocation = location;
            await FetchWeatherDataAsync();
        }
        
        /// <summary>
        /// Fetches weather data from the API
        /// </summary>
        public async Task FetchWeatherDataAsync()
        {
            try
            {
                // Cancel any previous weather request
                if (_weatherCts != null)
                {
                    _weatherCts.Cancel();
                    _weatherCts.Dispose();
                }
                
                // Create a new cancellation token source
                _weatherCts = new CancellationTokenSource();
                
                IsLoadingWeather = true;
                WeatherErrorMessage = null;
                NotifyStateChanged();
                
                // Add a small delay to simulate network latency and better demonstrate cancellation
                await Task.Delay(1000, _weatherCts.Token);
                
                // Make the API request
                string apiUrl = $"current.json?key={_weatherApiKey}&q={Uri.EscapeDataString(CurrentLocation)}";
                WeatherData = await _httpClient.GetFromJsonAsync<WeatherResponse>(apiUrl, _weatherCts.Token);
                
                IsLoadingWeather = false;
                NotifyStateChanged();
            }
            catch (OperationCanceledException)
            {
                // Request was canceled, do nothing
                // We don't set IsLoadingWeather = false here since a new request should be in progress
            }
            catch (Exception ex)
            {
                WeatherErrorMessage = $"Error fetching weather data: {ex.Message}";
                IsLoadingWeather = false;
                NotifyStateChanged();
            }
        }
        
        /// <summary>
        /// Fetches user data from the JSONPlaceholder API
        /// </summary>
        public async Task FetchUserDataAsync(int limit = 5)
        {
            try
            {
                // Cancel any previous user data request
                if (_usersCts != null)
                {
                    _usersCts.Cancel();
                    _usersCts.Dispose();
                }
                
                // Create a new cancellation token source
                _usersCts = new CancellationTokenSource();
                
                IsLoadingUsers = true;
                UsersErrorMessage = null;
                NotifyStateChanged();
                
                // Add a small delay to simulate network latency and better demonstrate cancellation
                await Task.Delay(1000, _usersCts.Token);
                
                // Make the API request
                string apiUrl = $"https://jsonplaceholder.typicode.com/users?_limit={limit}";
                UserData = await _httpClient.GetFromJsonAsync<List<User>>(apiUrl, _usersCts.Token);
                
                IsLoadingUsers = false;
                NotifyStateChanged();
            }
            catch (OperationCanceledException)
            {
                // Request was canceled, do nothing
                // We don't set IsLoadingUsers = false here since a new request should be in progress
            }
            catch (Exception ex)
            {
                UsersErrorMessage = $"Error fetching user data: {ex.Message}";
                IsLoadingUsers = false;
                NotifyStateChanged();
            }
        }
    }
} 