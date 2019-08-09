/**
 * Author: Pantelis Andrianakis
 * Date: April 21st 2019
 */
public class AnimationHolder
{
    public readonly float velocityX;
    public readonly float velocityZ;
    public readonly bool triggerJump;
    public readonly bool isInWater;
    public readonly bool isGrounded;

    public AnimationHolder(float velocityX, float velocityZ, bool triggerJump, bool isInWater, bool isGrounded)
    {
        this.velocityX = velocityX;
        this.velocityZ = velocityZ;
        this.triggerJump = triggerJump;
        this.isInWater = isInWater;
        this.isGrounded = isGrounded;
    }
}
