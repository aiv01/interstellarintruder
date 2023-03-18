using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Gun : MonoBehaviour
{
    #region SerializeField 
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private Transform targetPosition;
    #endregion

    void Update()
    {
        GunForward();
    }

    #region Private Method
    private void GunForward()
    {
        transform.position = targetPosition.position;
        transform.right = _player.transform.forward;
    }
    #endregion
}
