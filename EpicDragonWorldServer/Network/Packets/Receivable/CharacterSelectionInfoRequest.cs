/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class CharacterSelectionInfoRequest
{
    public CharacterSelectionInfoRequest(GameClient client, ReceivablePacket packet)
    {
        // Read data.
        string accountName = packet.ReadString().ToLowerInvariant();

        // If account has logged send the information.
        if (client.GetAccountName().Equals(accountName))
        {
            client.ChannelSend(new CharacterSelectionInfoResult(accountName));
        }
    }
}
