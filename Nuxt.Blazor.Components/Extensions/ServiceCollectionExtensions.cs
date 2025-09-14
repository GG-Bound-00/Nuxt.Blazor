using Microsoft.Extensions.DependencyInjection;
using Nuxt.Blazor.Components.JsInterop;

namespace Nuxt.Blazor.Components.Extensions;

public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddNuxtBlazorComponents(this IServiceCollection services)
	{
		services.AddScoped<IThemeJsInterop, ThemeJsInterop>();
		return services;
	}
}