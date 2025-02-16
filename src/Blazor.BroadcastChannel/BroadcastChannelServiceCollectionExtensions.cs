using Blazor.BroadcastChannel;

namespace Microsoft.Extensions.DependencyInjection
{
    /// <summary>
    /// The <see cref="IServiceCollection"/> extensions for adding Broadcast Channel API related services.
    /// </summary>
    public static class BroadcastChannelServiceCollectionExtensions
    {
        /// <summary>
        /// Registers a default transient service which provides support for Broadcast Channel API.
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        /// <returns>The collection of service descriptors.</returns>
        public static IServiceCollection AddBroadcastChannel(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();
            services.AddTransient<IBroadcastChannelService, BroadcastChannelService>();

            return services;
        }
        
        /// <summary>
        /// Registers a default singleton service which provides support for Broadcast Channel API.
        /// </summary>
        /// <param name="services">The collection of service descriptors.</param>
        /// <returns>The collection of service descriptors.</returns>
        public static IServiceCollection AddBroadcastChannelAsSingleton(this IServiceCollection services)
        {
            if (services is null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();
            services.AddSingleton<IBroadcastChannelService, BroadcastChannelService>();

            return services;
        }
    }
}
