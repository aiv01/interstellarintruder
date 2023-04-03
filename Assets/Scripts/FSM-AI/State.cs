using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    public enum STATE
    {
        Idle,
        Patrol,
        Chase,
        RangeAttack,
        MeleeAttack,
        Hit,
        Die
    }

    public enum EVENT
    {
        Enter,
        Update,
        Exit
    }

    public STATE stateType;
    protected EVENT stage;
    protected GameObject entity;
    protected Animator anim;
    protected Transform player;
    protected State nextState;
    protected NavMeshAgent agent;
    protected GranadierStats stats;
    protected EnemyAI enemy;
    

    public State(GameObject _entity, NavMeshAgent _agent, Animator _anim, Transform _player, GranadierStats _stats, EnemyAI _enemy)
    {
        entity = _entity;
        agent = _agent;
        anim = _anim;
        player = _player;
        stats = _stats;
        stage = EVENT.Enter;
        enemy = _enemy;
    }

    

    public virtual void Enter() { stage = EVENT.Update; }
    public virtual void Update() { stage = EVENT.Update; }
    public virtual void Exit() { stage = EVENT.Exit; }

    public State Process()
    {
        if (stage == EVENT.Enter) Enter();
        if (stage == EVENT.Update) Update();
        if(stage == EVENT.Exit)
        {
            Exit();
            return nextState;
        }
        return this;
    }

    public bool CanSeePlayer()
    {
        Vector3 direction = player.position - entity.transform.position;
        float angle = Vector3.Angle(direction, entity.transform.forward);

        if (direction.magnitude < stats.visDist && angle < stats.visAngle)
        {
            return true;
        }
        return false;
    }

    public bool IsPlayerBehind()
    {
        Vector3 direction = entity.transform.position - player.position;
        float angle = Vector3.Angle(direction, entity.transform.forward);
        if (direction.magnitude < stats.nearDist && angle < stats.visAngle) return true;
        return false;
    }

    public bool CanShootPlayer()
    {
        Vector3 direction = player.position - entity.transform.position;
        if(direction.magnitude < stats.rangeDist)
        {
            return true;
        }
        return false;
    }

    public bool CanMeleePlayer()
    {
        Vector3 direction = player.position - entity.transform.position;
        if (direction.magnitude < stats.meleeDist)
        {
            return true;
        }
        return false;
    }

    public bool Die()
    {
        return enemy.currentHp <= 0.0f;
    }

    public bool Hit()
    {
        return enemy.Hitted;
    }
    
}
