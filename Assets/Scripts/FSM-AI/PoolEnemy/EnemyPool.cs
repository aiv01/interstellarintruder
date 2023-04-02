using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField]
    private GranadierStats _stats;
    [SerializeField]
    private Enemy enemyPrefab;

    private int poolSize = 10;
    private List<Enemy> pool = new List<Enemy>();

    private void Awake()
    {
        FillPool();
    }

    public void FillPool()
    {
        for (int i = 0; i < poolSize; i++)
            CreateInstance();
    }

    private Enemy CreateInstance()
    {
        Enemy instance = Instantiate<Enemy>(enemyPrefab);
        //instance.gameObject.SetActive(false);
        instance.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        instance.transform.SetParent(transform);
        pool.Add(instance);
        return instance;
    }

    public Enemy GetEnemy()
    {
        Enemy val = null;
        foreach (Enemy eneemy in pool)
            if (!eneemy.gameObject.activeSelf)
            {
                val = eneemy;
                break;
            }
        val.gameObject.SetActive(true);
        val.gameObject.GetComponent<GranadierStats>().healthPoint = 10;
        return val;
    }
}
