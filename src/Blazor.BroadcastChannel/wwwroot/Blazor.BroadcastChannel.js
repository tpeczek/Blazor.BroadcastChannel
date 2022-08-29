const channels = {};

export function createOrJoin(connectionId, channelName) {
    if (!channels.hasOwnProperty(connectionId)) {
        channels[connectionId] = new BroadcastChannel(channelName);
    } else if (channels[connectionId].name !== channelName) {
        throw new Error('A connection with provided identifier has already been established to a different channel.');
    }

    return { ConnectionId: connectionId, Name: channels[connectionId].name };
}

export function close(connectionId) {
    if (channels.hasOwnProperty(connectionId)) {
        channels[connectionId].close();
        delete channels[connectionId];
    }
}