/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class AccountAuthenticationResult : SendablePacket
{
    public AccountAuthenticationResult(int result)
    {
        // Send the data.
        WriteShort(1); // Packet id.
        WriteByte(result); // 0 does not exist, 1 banned, 2 requires activation, 3 wrong password, 4 already logged, 5 too many online, 6 incorrect client, 100 authenticated
    }
}
