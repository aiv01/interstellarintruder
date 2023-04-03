using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField]
    private Enemy enemyToSpawn;
    private Enemy myEnemy;
    private EnemyPool _enemyPool;

    private void Awake()
    {
        _enemyPool = GetComponent<EnemyPool>();
        _enemyPool.FillPool();
    }

    public override void Despawn()
    {
        Destroy(myEnemy);
    }

    public override void Spawn()
    {
        myEnemy = Instantiate<Enemy>(enemyToSpawn, this.transform, false);

        TileInfo.enemyCounter += 1;
    }
    
}
