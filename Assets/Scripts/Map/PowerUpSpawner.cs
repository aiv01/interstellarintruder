using PowerUp;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : Spawner
{
    private PowerUpPool pool;
    private PowerUpBase myPower;
    public override void Despawn()
    {
        myPower = null;
    }
    private void Awake()
    {
        Init();
    }
    public override void Init()
    {
        pool = FindObjectOfType<PowerUpPool>();
        base.Init();
    }

    public override void Spawn()
    {
        myPower = pool.GetPowerUp();
        myPower.transform.position = transform.position;
    }
}
