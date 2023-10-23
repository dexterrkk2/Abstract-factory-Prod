using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Client : MonoBehaviour
{
    public int slowEnemies;
    public int bigEnemies;
    public int fastEnemies;
    public List<Transform> spawnpoints;
    WaveRequirements waveRequirements;
    public IMob mob;
    public Text slowEnemiesNum;
    public Text fastEnemiesNum;
    public Text bigEnemiesNum;
    public Text spawnText;
    public int count;
    private void Start()
    {
        waveRequirements = new WaveRequirements();
        int enemyTotal = slowEnemies + bigEnemies + fastEnemies;
        if (enemyTotal != 0)
        {
            UpdateRequirements();
        }
    }
    public void Update()
    {
        slowEnemiesNum.text = "Number of mediun units to spawn" + slowEnemies;
        fastEnemiesNum.text = "Number of small units to spawn" + fastEnemies;
        bigEnemiesNum.text = "Number of Giants to spawn" + bigEnemies;
    }
    private static IMob GetMob(WaveRequirements requirements)
    {
        MobFactory factory = new MobFactory(requirements);
        return factory.Create();
    }
    public void UpdateSlowMobs(int num)
    {
        slowEnemies += num;
    }
    public void UpdateBigMobs(int num)
    {
        bigEnemies += num;
    }
    public void UpdateFastMobs(int num)
    {
        fastEnemies += num;
    }
    public void UpdateRequirements()
    {
        waveRequirements.slowMobs = slowEnemies;
        waveRequirements.fastMobs = fastEnemies;
        waveRequirements.bigMobs = bigEnemies;
        int enemyTotal = waveRequirements.slowMobs + waveRequirements.bigMobs + waveRequirements.fastMobs;
        while(enemyTotal > 0)
        {
            if (count > spawnpoints.Count - 1)
            {
                count = 0;
            }
            mob = GetMob(waveRequirements);
            spawnText.text = "Spawned a " + mob.ToString();
            GameObject instance = Instantiate(Resources.Load(mob.ToString(), typeof(GameObject)), spawnpoints[count]) as GameObject;
            enemyTotal = waveRequirements.slowMobs + waveRequirements.bigMobs + waveRequirements.fastMobs;
            count++;
            
        }
        slowEnemies = 0;
        fastEnemies = 0;
        bigEnemies = 0;
    }
}
