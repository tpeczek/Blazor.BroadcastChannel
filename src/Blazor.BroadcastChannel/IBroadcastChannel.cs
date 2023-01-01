namespace Blazor.BroadcastChannel
{
    /// <summary>
    /// An interface which represents a named channel that any browsing context of a given origin can subscribe to. It allows communication between different documents (in different windows, tabs, frames or iframes) of the same origin.
    /// </summary>
    public interface IBroadcastChannel : IAsyncDisposable
    {
        /// <summary>
        /// The name of the channel.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Occurs when a message arrives on the underlying channel.
        /// </summary>
        event EventHandler<BroadcastChannelMessageEventArgs>? Message;

        /// <summary>
        /// Terminates the connection to the underlying channel.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task CloseAsync();

        /// <summary>
        /// Sends a message to the underlying channel.
        /// </summary>
        /// <typeparam name="TValue">The type of the data to be sent to the underlying channel</typeparam>
        /// <param name="data">The data to be sent to the underlying channel.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task PostMessageAsync<TValue>(TValue data);
    }
}
