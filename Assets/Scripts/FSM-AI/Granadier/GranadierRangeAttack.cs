using UnityEngine;
using UnityEngine.AI;
using Weapon.Shoot;

public class GranadierRangeAttack : State
{
    public GranadierRangeAttack(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats, EnemyAI _enemy) : base(_entity, _agent, _anim, _player, _stats, _enemy)
    {
        stateType = STATE.RangeAttack;
    }

    public override void Enter()
    {
        
        agent.isStopped = true;
        //anim.SetTrigger("TurnTrigger");
        base.Enter();
    }

    public override void Update()
    {
        Vector3 direction = player.position - entity.transform.position;
        float angle = Vector3.Angle(direction, entity.transform.forward);
        direction.y = 0.0f;

        entity.transform.rotation = Quaternion.Slerp(entity.transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * stats.rotationSpeed);
        
        //anim.SetFloat("Angle", angle);

        if(angle < 5f)
        {
            anim.SetTrigger("RangeAttack");
        }
        
        if (Die())
        {
            nextState = new GranadierDie(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        } else if (Hit())
        {
            nextState = new GranadierHit(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        }
        if (CanMeleePlayer())
        {
            nextState = new GranadierMeleeAttack(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        } else if (!CanShootPlayer())
        {
            nextState = new GranadierIdle(entity, agent, anim, player, stats, enemy);
            stage = EVENT.Exit;
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
