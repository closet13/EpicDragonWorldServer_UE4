using System;

/**
 * Author: Pantelis Andrianakis
 * Date: November 7th 2018
 */
public class Creature : WorldObject
{
    private long currentHp = 0;
    private long currentMp = 0;

    public void SetCurrentHp(long value)
    {
        currentHp = value;
    }

    public long GetCurrentHp()
    {
        return currentHp;
    }

    public void SetCurrentMp(long value)
    {
        currentMp = value;
    }

    public long GetCurrentMp()
    {
        return currentMp;
    }

    public override bool IsCreature()
    {
        return true;
    }

    public override Creature AsCreature()
    {
        return this;
    }

    public override string ToString()
    {
        return "Creature [" + GetObjectId() + "]";
    }
}
