using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.AI;

public class GranadierRangeAttack : State
{
    public GranadierRangeAttack(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats) : base(_entity, _agent, _anim, _player, _stats)
    {
        stateType = STATE.RangeAttack;
    }

    public override void Enter()
    {
        
        agent.isStopped = true;
        base.Enter();
    }

    public override void Update()
    {
        Debug.Log("Range");
        Vector3 direction = player.position - entity.transform.position;
        float angle = Vector3.Angle(direction, entity.transform.forward);
        direction.y = 0.0f;

        entity.transform.rotation = Quaternion.Slerp(entity.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * stats.rotationSpeed);
        //Fare turn con animatore

        if(angle < 5f)
        {
            //shoot event
        }

        if (CanMeleePlayer())
        {
            nextState = new GranadierMeleeAttack(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        } else if (!CanShootPlayer())
        {
            nextState = new GranadierIdle(entity, agent, anim, player, stats);
            stage = EVENT.Exit;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
