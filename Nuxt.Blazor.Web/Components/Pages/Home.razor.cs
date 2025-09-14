namespace Nuxt.Blazor.Web.Components.Pages;

public partial class Home
{
	bool isDarkMode;

	async Task ToggleThemeAsync()
	{
		isDarkMode = !isDarkMode;
		await Task.CompletedTask;
	}
}
