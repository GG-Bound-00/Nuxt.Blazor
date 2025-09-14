using Microsoft.AspNetCore.Components;
using Nuxt.Blazor.Components.JsInterop;

namespace Nuxt.Blazor.Components;

public partial class ThemeProvider : IAsyncDisposable
{
	[Inject]
	IThemeJsInterop? ThemeJsInterop { get; set; }

	[Parameter]
	public bool IsDarkMode { get; set; }

	bool previousDarkMode;

	string ClassNames => IsDarkMode ? "dark" : "light";

	protected override async Task OnAfterRenderAsync(bool firstRender)
	{
		if (firstRender || previousDarkMode != IsDarkMode)
		{
			previousDarkMode = IsDarkMode;
			await (ThemeJsInterop?.SetThemeAttributeAsync(ClassNames) ?? Task.CompletedTask);
		}
	}

	public async ValueTask DisposeAsync()
	{
		if (ThemeJsInterop != null)
		{
			await ThemeJsInterop.DisposeAsync();
		}
	}
}
