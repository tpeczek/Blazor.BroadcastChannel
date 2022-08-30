using Microsoft.JSInterop;

namespace Blazor.BroadcastChannel
{
    internal class BroadcastChannel : IBroadcastChannel
    {
        private BroadcastChannelService? _broadcastChannelService;

        public event EventHandler<BroadcastChannelMessageEventArgs>? Message;

        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public async Task InitializeAsync(BroadcastChannelService broadcastChannelService)
        {
            _broadcastChannelService = broadcastChannelService;

            await _broadcastChannelService.AddMessageEventListener(this);
        }

        public async Task CloseAsync()
        {
            if (_broadcastChannelService is not null)
            {
                await _broadcastChannelService.CloseAsync(Id);
            }
        }

        public Task PostMessageAsync<TValue>(TValue data)
        {
            if (_broadcastChannelService is null)
            {
                throw new InvalidOperationException($"The {nameof(BroadcastChannel)} was not properly initialized.");
            }

            return _broadcastChannelService.PostMessageAsync(Id, data);
        }

        [JSInvokable]
        public void OnMessage(BroadcastChannelMessageEvent messageEvent)
        {
            Message?.Invoke(this, new BroadcastChannelMessageEventArgs(messageEvent));
        }

        public async ValueTask DisposeAsync()
        {
            await CloseAsync();
        }        
    }
}
