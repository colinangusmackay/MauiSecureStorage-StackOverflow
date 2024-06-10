using System;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;

namespace MauiSecureStorage;

public partial class MainPage : ContentPage
{
    private readonly ILogger<MainPage> _logger;

    public MainPage(ILogger<MainPage> logger)
    {
        _logger = logger;
        InitializeComponent();
    }

    private async void SetSecureStorage_OnClicked(object? sender, EventArgs e)
    {
        try
        {
            var value = NewValue.Text;
            await SecureStorage.SetAsync("MauiSecureStorageValue", value);
            await DisplayAlert("Set Value", $"Set value to {value}", "Okay");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Exception happened.");
        }
    }

    private async void GetSecureStorage_OnClicked(object? sender, EventArgs e)
    {
        var value = await SecureStorage.Default.GetAsync("MauiSecureStorageValue");
        await DisplayAlert("Get Value", $"The value in secure storage is `{value}`", "Okay");
    }
}