# Blazor.BroadcastChannel
[![NuGet Version](https://img.shields.io/nuget/v/Blazor.BroadcastChannel?label=Blazor.BroadcastChannel&logo=nuget)](https://www.nuget.org/packages/Blazor.BroadcastChannel/)

This is a HTML5 [Broadcast Channel API](https://developer.mozilla.org/en-US/docs/Web/API/Broadcast_Channel_API) implementation for Blazor.

The Broadcast Channel API allows sending messages to other browsing contexts on the same origin. It can be thought of as a simple message bus that allows pub/sub semantics between windows/tabs, iframes, web workers, and service workers.

## How to use Blazor.BroadcastChannel

### Getting Started

1. Install the NuGet package `Blazor.BroadcastChannel`.
    ```
    dotnet add Blazor.BroadcastChannel 
    ```
2. In `Program.cs` add `builder.Services.AddBroadcastChannel`.
    ```
    ...

    var builder = WebAssemblyHostBuilder.CreateDefault(args);

    ...

    builder.Services.AddBroadcastChannel();

    ...

    await builder.Build().RunAsync();
    ```
3. Add the `Blazor.BroadcastChannel` namespace in `_Imports.razor` or the component in which you want to use the Broadcast Channel API.
    ```
    @using Blazor.BroadcastChannel
    ```
4. Inject the `IBroadcastChannelService` in the component in which you want to use the Broadcast Channel API.
    ```
    @inject IBroadcastChannelService BroadcastChannelService
    ```

### Creating or Joining a Channel
The `IBroadcastChannelService.CreateOrJoinAsync` method allows for joining a broadcast channel. It takes a single parameter, which is the name of the channel.  It returns an instance of `IBroadcastChannel` which represents the channel.

```
IBroadcastChannel broadcastChannel = await BroadcastChannelService.CreateOrJoinAsync("checkout:item-added");
```

If it is the first connection to that broadcast channel, the underlying channel is created.

### Sending a Message
To send a message, it is enough to call the `IBroadcastChannel.PostMessageAsync` method, which takes any object as an argument.

```
await broadcastChannel.PostMessageAsync(new CheckoutItem { Sku = Sku, Edition = Edition });
```

The API doesn't associate any semantics to messages, so it is up to the receiving code to know what kind of messages to expect and how to handle them.

### Receiving a Message
In order to receive messages, it is enough to subscribe to `IBroadcastChannel.Message` event. The sent object is available as `JsonDocument` through `BroadcastChannelMessageEventArgs.Data` property.

```
broadcastChannel.Message += (object? sender, BroadcastChannelMessageEventArgs e) =>
{
    Console.WriteLine(JsonSerializer.Serialize(e.Data));
};
```

### Disconnecting a Channel
To leave a broadcast channel, either dispose the `IBroadcastChannel` or call `IBroadcastChannel.CloseAsync` method.

```
await broadcastChannel.DisposeAsync();
```

It is important to disconnect from the channel to allow the underlying JavaScript object to be garbage collected.

## Demos

You can see Blazor.BroadcastChannel in action as part of [Demo.AspNetCore.MicroFrontendsInAction](https://github.com/tpeczek/Demo.AspNetCore.MicroFrontendsInAction/tree/main/12-child-child-communication-with-blazor-webassembly-based-web-components).

## Donating

My blog and open source projects are result of my passion for software development, but they require a fair amount of my personal time. If you got value from any of the content I create, then I would appreciate your support by [sponsoring me](https://github.com/sponsors/tpeczek) (either monthly or one-time).

## Copyright and License

Copyright © 2022 Tomasz Pęczek

Licensed under the [MIT License](https://github.com/tpeczek/Blazor.BroadcastChannel/blob/master/LICENSE.md)