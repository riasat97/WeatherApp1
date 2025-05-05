# WeatherApp - Blazor WebAssembly Demo

A demonstration Blazor WebAssembly application that showcases API integration, dynamic UI updates, and state management patterns.

## Features

- **Weather API Integration**: Fetch and display real-time weather data from WeatherAPI.com
- **User Data API Integration**: Fetch user data from JSONPlaceholder API
- **Cancellation Token Support**: Handle overlapping API requests efficiently
- **State Management**: Centralized state management with notification system
- **Responsive UI**: Clean, Bootstrap-based interface with loading indicators and error handling

## Components

### WeatherFetch
Demonstrates direct API integration with error handling and CORS considerations. Features:
- Weather data display with icons
- Location search
- Error handling and recovery

### DynamicWeather
Showcases dynamic updates and cancellation token usage. Features:
- Random limit parameter to demonstrate cancellation
- Refresh button to trigger new data fetches
- Visual feedback when requests are cancelled

### SharedStateDemo
Demonstrates proper state management using service injection. Features:
- Shared state between API data sources
- Automatic UI updates when state changes
- Event-based notification system

## Technical Implementation

### State Management
The application demonstrates a simple but effective state management approach using:
- Injectable services with state storage
- Event-based notification system
- Component subscriptions
- Proper cleanup to prevent memory leaks

### API Integration
Two different APIs are integrated:
- WeatherAPI.com - for real-time weather data
- JSONPlaceholder - for sample user data

### Cancellation Handling
The application properly handles cancellation of in-flight requests when new ones are initiated using:
- CancellationTokenSource
- CancellationToken passing to API calls
- Proper disposal of tokens

## Getting Started

1. Clone the repository
2. Ensure you have .NET 9.0 SDK installed
3. Run `dotnet restore` to restore dependencies
4. Run `dotnet run` to start the application
5. Navigate to the displayed URL (typically https://localhost:5001)

## Project Structure

```
WeatherApp1/
├── Models/              # Data models for APIs
│   ├── User.cs          # JSONPlaceholder API model
│   └── WeatherData.cs   # Weather API model
├── Pages/               # Razor components
│   ├── WeatherFetch.razor     # Direct API integration
│   ├── DynamicWeather.razor   # Cancellation demo
│   └── SharedStateDemo.razor  # State management demo
├── Services/            # Services for state and API access
│   └── WeatherStateService.cs # Shared state service
├── Layout/              # UI layout components
├── Program.cs           # Application startup and DI configuration
└── _Imports.razor       # Global using statements
```

## Key Concepts Demonstrated

1. **Component Lifecycle**: Using OnInitialized, OnInitializedAsync, and Dispose
2. **Dependency Injection**: Service registration and injection
3. **Event Handling**: Subscription and cleanup
4. **Asynchronous Programming**: Async/await with proper cancellation
5. **State Management**: Maintaining and sharing state between components

## API Keys

The application uses a demo API key for WeatherAPI.com. For production use, you should:
1. Register for your own API key at [WeatherAPI.com](https://www.weatherapi.com/)
2. Update the API key in the WeatherStateService.cs file

## Browser Support

The application should work in all modern browsers that support WebAssembly. 