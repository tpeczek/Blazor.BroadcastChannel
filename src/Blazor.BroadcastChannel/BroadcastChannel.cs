namespace Blazor.BroadcastChannel
{
    internal class BroadcastChannel : IBroadcastChannel
    {
        private BroadcastChannelService? _broadcastChannelService;

        public string Id { get; set; } = String.Empty;

        public string Name { get; set; } = String.Empty;

        public void SetSerive(BroadcastChannelService broadcastChannelService)
        {
            _broadcastChannelService = broadcastChannelService;
        }

        public async Task CloseAsync()
        {
            if (_broadcastChannelService is not null)
            {
                await _broadcastChannelService.CloseAsync(Id);
            }
        }

        public async ValueTask DisposeAsync()
        {
            await CloseAsync();
        }
    }
}
