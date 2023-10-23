using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMobFactory 
{
    IMob Create(WaveRequirements waveRequirements);
}
public class SlowFactory: IMobFactory
{
    public IMob Create(WaveRequirements waveRequirements)
    {
        int random = Random.Range(0,3);
        if(random == 0)
        {
            return new Zombie();
        }
        if(random == 1)
        {
            return new Alien();
        }
        if(random == 2)
        {
            return new Skeleton();
        }
        if(random == 3)
        {
            return new Necromancer();
        }
        return null;
    }
}
public class BigFactory : IMobFactory
{
    public IMob Create(WaveRequirements waveRequirements)
    {
        int random = Random.Range(0, 3);
        if (random == 0)
        {
            return new Giant();
        }
        if (random == 1)
        {
            return new Golem();
        }
        if (random == 2)
        {
            return new Dragon();
        }
        if (random == 3)
        {
            return new Demon();
        }
        return null;
    }
}
public class FastFactory : IMobFactory
{
    public IMob Create(WaveRequirements waveRequirements)
    {
        int random = Random.Range(0,2);
        if (random == 0)
        {
            return new Goblin();
        }
        if (random == 1)
        {
            return new Ghost();
        }
        if (random == 2)
        {
            return new Kobold();
        }
        return null;
    }
}
public abstract class AbstractMobFactory
{
    public abstract IMob Create();
}
public class MobFactory: AbstractMobFactory
{
    private readonly IMobFactory mobFactory;
    private readonly WaveRequirements _requirements;
    public MobFactory(WaveRequirements requirements)
    {
        if(requirements.slowMobs != 0)
        {
            mobFactory = (IMobFactory)new SlowFactory();
            requirements.slowMobs--;
        }
        else if(requirements.bigMobs != 0)
        {
            mobFactory = (IMobFactory)new BigFactory();
            requirements.bigMobs--;
        }
        else if (requirements.fastMobs != 0)
        {
            mobFactory = (IMobFactory)new FastFactory();
            requirements.fastMobs--;
        }
        _requirements = requirements;
    }
    public override IMob Create()
    {
        return mobFactory.Create(_requirements);
    }
}