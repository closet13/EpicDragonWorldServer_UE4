/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class GameClientPacketHandler
{
    public static void Handle(GameClient client, ReceivablePacket packet)
    {
        /*
        switch (packet.ReadShort()) // Packet id.
        {
            case 1:
                new AccountAuthenticationRequest(client, packet);
                break;

            case 2:
                new CharacterSelectionInfoRequest(client, packet);
                break;

            case 3:
                new CharacterCreationRequest(client, packet);
                break;

            case 4:
                new CharacterDeletionRequest(client, packet);
                break;

            case 5:
                new CharacterSlotUpdate(client, packet);
                break;

            case 6:
                new CharacterSelectUpdate(client, packet);
                break;

            case 7:
                new EnterWorldRequest(client, packet);
                break;

            case 8:
                new ExitWorldRequest(client, packet);
                break;

            case 9:
                new LocationUpdateRequest(client, packet);
                break;

            case 10:
                new AnimatorUpdateRequest(client, packet);
                break;

            case 11:
                new ObjectInfoRequest(client, packet);
                break;

            case 12:
                new PlayerOptionsUpdate(client, packet);
                break;

            case 13:
                new ChatRequest(client, packet);
                break;
        }
		*/

		// Test receive.
		LogManager.Log("" + packet.ReadByte());
        LogManager.Log("" + packet.ReadShort());
        LogManager.Log("" + packet.ReadInt());
        LogManager.Log("" + packet.ReadLong());
        LogManager.Log("" + packet.ReadFloat());
        LogManager.Log("" + packet.ReadDouble());
        LogManager.Log("" + packet.ReadString());

		// Test send.
        SendablePacket send = new SendablePacket();
        send.WriteShort(1); // id
        send.WriteString("All is good!");
        client.ChannelSend(send);
    }
}
