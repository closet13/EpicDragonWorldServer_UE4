/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class ChatRequest
{
    public ChatRequest(GameClient client, ReceivablePacket packet)
    {
        // Read data.
        string message = packet.ReadString();

        // Handle message.
        Player sender = client.GetActiveChar();
        if (sender != null)
        {
            ChatManager.HandleChat(sender, message);
        }
    }
}
