/**
 * Author: Pantelis Andrianakis
 * Date: February 4th 2019
 */
public class AnimatorUpdate : SendablePacket
{
    public AnimatorUpdate(long objectId, float velocityX, float velocityY, bool triggerJump, bool isInWater, bool isGrounded)
    {
        // Send the data.
        WriteShort(10); // Packet id.
        WriteLong(objectId);
        WriteFloat(velocityX);
        WriteFloat(velocityY);
        WriteByte(triggerJump ? 1 : 0);
        WriteByte(isInWater ? 1 : 0);
        WriteByte(isGrounded ? 1 : 0);
    }
}
