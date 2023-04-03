using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Spawner : MonoBehaviour
{
    private IsaacTileInfo tileInfo;
    protected IsaacTileInfo TileInfo
    {
        get { if(tileInfo == null) tileInfo = GetComponentInParent<IsaacTileInfo>();
            return tileInfo;
        }
    }
    
    public virtual void Init()
    {
        tileInfo = GetComponentInParent<IsaacTileInfo>();
    }
    public abstract void Spawn();
    public abstract void Despawn();
}
