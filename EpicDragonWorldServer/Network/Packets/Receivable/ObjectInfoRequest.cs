using System.Threading.Tasks;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class ObjectInfoRequest
{
    public ObjectInfoRequest(GameClient client, ReceivablePacket packet)
    {
        // Read data.
        long objectId = packet.ReadLong();

        // Get the acting player.
        Player player = client.GetActiveChar();
        // Send the information.
        foreach (WorldObject obj in WorldManager.GetVisibleObjects(player))
        {
            if (obj.GetObjectId() == objectId)
            {
                if (obj.IsPlayer())
                {
                    client.ChannelSend(new PlayerInformation(obj.AsPlayer()));
                }
                // TODO: Other objects - NpcInformation?

                // Send delayed animation update in case object was already moving.
                Task.Delay(1000).ContinueWith(task => SendAnimationInfo(client, obj));
                break;
            }
        }
    }

    private void SendAnimationInfo(GameClient client, WorldObject obj)
    {
        if (obj != null)
        {
            AnimationHolder animations = obj.GetAnimations();
            if (animations != null)
            {
                client.ChannelSend(new AnimatorUpdate(obj.GetObjectId(), animations.velocityX, animations.velocityZ, animations.triggerJump, animations.isInWater, animations.isGrounded));
            }
        }
    }
}
