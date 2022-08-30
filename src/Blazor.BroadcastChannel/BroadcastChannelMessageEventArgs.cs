using System.Text.Json;

namespace Blazor.BroadcastChannel
{
    internal class BroadcastChannelMessageEvent
    {
        public JsonDocument? Data { get; set; }

        public string? Origin { get; set; }

        public string? LastEventId { get; private set; }
    }

    /// <summary>
    /// Provides information about a message which has arrived on a channel.
    /// </summary>
    public class BroadcastChannelMessageEventArgs : EventArgs
    {
        /// <summary>
        /// Gets the data sent by the message emitter.
        /// </summary>
        public JsonDocument Data { get; private set; }

        /// <summary>
        /// Gets the origin of the message emitter.
        /// </summary>
        public string Origin { get; private set; }

        /// <summary>
        /// Gets a unique ID for the event.
        /// </summary>
        public string? LastEventId { get; private set; }

        internal BroadcastChannelMessageEventArgs(BroadcastChannelMessageEvent messageEvent)
        {
            if (messageEvent is null)
            {
                throw new ArgumentNullException(nameof(messageEvent));
            }

            Data = messageEvent.Data ?? throw new ArgumentNullException($"{nameof(messageEvent)}.{nameof(messageEvent.Data)}");
            Origin = messageEvent.Origin ?? throw new ArgumentNullException($"{nameof(messageEvent)}.{nameof(messageEvent.Origin)}");
            LastEventId = messageEvent.LastEventId;
        }   
    }
}
