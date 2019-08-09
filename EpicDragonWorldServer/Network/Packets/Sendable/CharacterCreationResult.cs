/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class CharacterCreationResult : SendablePacket
{
    public CharacterCreationResult(int result)
    {
        // Send the data.
        WriteShort(3); // Packet id.
        WriteByte(result);
    }
}
