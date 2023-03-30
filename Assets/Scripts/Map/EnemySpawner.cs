using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField]
    private Enemy enemyToSpawn;
    private Enemy myEnemy;
    public override void Despawn()
    {
        Destroy(myEnemy);
    }

    public override void Spawn()
    {
        myEnemy = Instantiate<Enemy>(enemyToSpawn,this.transform,false);
        
        TileInfo.enemyCounter += 1;
    }
    
}
