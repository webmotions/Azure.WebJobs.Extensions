using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using WebMotions.Azure.Functions.Worker.Extensions.Slack.Config;

namespace WebMotions.Azure.Functions.Worker.Extensions.Slack.Extensions;

/// <summary>
/// Provides extension methods to work with a <see cref="IFunctionsWorkerApplicationBuilder"/>.
/// </summary>
public static class FunctionsWorkerApplicationBuilderExtensions
{
    /// <summary>
    /// Configures the Slack extension.
    /// </summary>
    /// <param name="builder">The <see cref="IFunctionsWorkerApplicationBuilder"/> to configure.</param>
    /// <returns>The same instance of the <see cref="IFunctionsWorkerApplicationBuilder"/> for chaining.</returns>
    public static IFunctionsWorkerApplicationBuilder ConfigureSlackExtension(this IFunctionsWorkerApplicationBuilder builder)
    {
        if (builder == null)
        {
            throw new ArgumentNullException(nameof(builder));
        }

        builder.Services.AddOptions<SlackBindingOptions>();
        builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IConfigureOptions<SlackBindingOptions>, SlackBindingOptionsSetup>());

        return builder;
    }
}