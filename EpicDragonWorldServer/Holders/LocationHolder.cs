/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class LocationHolder
{
    float x;
    float y;
    float z;
    float heading;

    public LocationHolder(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        heading = 0;
    }

    public LocationHolder(float x, float y, float z, float heading)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.heading = heading;
    }

    public float GetX()
    {
        return x;
    }

    public void SetX(float x)
    {
        this.x = x;
    }

    public float GetY()
    {
        return y;
    }

    public void SetY(float y)
    {
        this.y = y;
    }

    public float GetZ()
    {
        return z;
    }

    public void SetZ(float z)
    {
        this.z = z;
    }

    public float GetHeading()
    {
        return heading;
    }

    public void SetHeading(float heading)
    {
        this.heading = heading;
    }
}
