/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class DeleteObject : SendablePacket
{
    public DeleteObject(WorldObject obj)
    {
        // Send the data.
        WriteShort(7); // Packet id.
        WriteLong(obj.GetObjectId()); // ID of object to delete.
    }
}
