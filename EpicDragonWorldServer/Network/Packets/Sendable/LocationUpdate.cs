/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class LocationUpdate : SendablePacket
{
    private readonly WorldObject obj;
    private readonly bool teleport;

    public LocationUpdate(WorldObject obj)
    {
        this.obj = obj;
        teleport = false;
        WriteData();
    }

    // Only used for client active player teleports.
    public LocationUpdate(WorldObject obj, bool teleport)
    {
        this.obj = obj;
        this.teleport = teleport;
        WriteData();
    }

    private void WriteData()
    {
        WriteShort(9); // Packet id.
        WriteLong(teleport ? 0 : obj.GetObjectId());
        WriteFloat(obj.GetLocation().GetX());
        WriteFloat(obj.GetLocation().GetY());
        WriteFloat(obj.GetLocation().GetZ());
        WriteFloat(obj.GetLocation().GetHeading());
    }
}
