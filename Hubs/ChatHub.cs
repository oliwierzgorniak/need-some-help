using Microsoft.AspNetCore.SignalR;

namespace NeedSomeHelp.Hubs;

public class ChatHub : Hub
{
    public async Task JoinChat(int requestId, string userId1, string userId2)
    {
        var groupName = GetGroupName(requestId, userId1, userId2);
        await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
    }

    public async Task SendMessage(int requestId, string senderId, string receiverId, string content)
    {
        var groupName = GetGroupName(requestId, senderId, receiverId);
        await Clients.Group(groupName).SendAsync("ReceiveMessage", senderId, content);
    }

    private string GetGroupName(int requestId, string userId1, string userId2)
    {
        var userIds = new List<string> { userId1, userId2 };
        userIds.Sort(); // Ensure stable group name regardless of who joins first
        return $"chat_{requestId}_{string.Join("_", userIds)}";
    }
}
