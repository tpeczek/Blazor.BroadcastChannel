namespace Blazor.BroadcastChannel
{
    /// <summary>
    /// An interface for service which provides support for Broadcast Channel API.
    /// </summary>
    public interface IBroadcastChannelService
    {
        /// <summary>
        /// Creates or joins (if it already exists) an <see cref="IBroadcastChannel"/>.
        /// </summary>
        /// <param name="channelName">The name of the channel.</param>
        /// <returns>The <see cref="IBroadcastChannel"/>.</returns>
        Task<IBroadcastChannel> CreateOrJoinAsync(string channelName);
    }
}