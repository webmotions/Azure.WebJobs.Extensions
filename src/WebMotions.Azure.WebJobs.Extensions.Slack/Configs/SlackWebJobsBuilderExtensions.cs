using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebMotions.Azure.WebJobs.Extensions.Slack.Configs
{
    public static class SlackWebJobsBuilderExtensions
    {
        /// <summary>
        /// Adds the Slack extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> to configure.</param>
        public static IWebJobsBuilder AddSlack(this IWebJobsBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AddExtension<SlackExtensionConfigProvider>()
                    .ConfigureOptions<SlackOptions>((rootConfig, extensionPath, options) =>
                    {
                        options.ApiKey = rootConfig[SlackOptions.AzureWebJobsSlackApiKey];
                        options.WebHookUrl = rootConfig[SlackOptions.AzureWebJobsSlackWebHookUrl];

                        IConfigurationSection section = rootConfig.GetSection(extensionPath);
                        section.Bind(options);
                    });

            builder.Services.AddHttpClient<ISlackHttpClient, SlackHttpClient>();

            return builder;
        }

        /// <summary>
        /// Adds the Slack extension to the provided <see cref="IWebJobsBuilder"/>.
        /// </summary>
        /// <param name="builder">The <see cref="IWebJobsBuilder"/> to configure.</param>
        /// <param name="configure">An <see cref="Action{SlackOptions}"/> to configure the provided <see cref="SlackOptions"/>.</param>
        public static IWebJobsBuilder AddSlack(this IWebJobsBuilder builder, Action<SlackOptions> configure)
        {
            if (builder == null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            builder.AddSlack();
            builder.Services.Configure(configure);
            builder.Services.AddHttpClient<ISlackHttpClient, SlackHttpClient>();

            return builder;
        }
    }
}