using Microsoft.JSInterop;

namespace Nuxt.Blazor.Components.JsInterop;

public interface IThemeJsInterop : IAsyncDisposable
{
	Task SetThemeAttributeAsync(string theme);
}

public class ThemeJsInterop : IThemeJsInterop, IAsyncDisposable
{
	private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

	public ThemeJsInterop(IJSRuntime jsRuntime)
	{
		_moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
			"import", "./_content/Nuxt.Blazor.Components/js/themeProvider.js").AsTask());
	}

	public async Task SetThemeAttributeAsync(string theme)
	{
		var module = await _moduleTask.Value;
		await module.InvokeVoidAsync("NuxtTheme.setThemeAttribute", theme);
	}

	public async ValueTask DisposeAsync()
	{
		if (_moduleTask.IsValueCreated)
		{
			var module = await _moduleTask.Value;
			await module.DisposeAsync();
		}
	}
}