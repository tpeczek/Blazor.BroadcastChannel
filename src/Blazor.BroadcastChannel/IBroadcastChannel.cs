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
        public string Name { get; }

        /// <summary>
        /// Terminates the connection to the underlying channel.
        /// </summary>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task CloseAsync();
    }
}
