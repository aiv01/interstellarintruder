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

    protected override void Start()
    {
        pool = FindObjectOfType<PowerUpPool>();
    }

    public override void Spawn()
    {
        myPower = pool.GetPowerUp();
        myPower.transform.position = transform.position;
    }
}
