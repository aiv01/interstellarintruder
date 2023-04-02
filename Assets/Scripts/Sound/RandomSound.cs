using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource myStepSource;
    [SerializeField]
    private AudioSource myRangedSource;
    [SerializeField]
    private AudioSource myMeleeSource;
    public List<AudioClip> walkStepClip;
    public List<AudioClip> runStepClip;
    public List<AudioClip> rangedAttackClip;
    public List<AudioClip> meleeAttackClip;
    public List<AudioClip> screamAttackClip;
    public List<AudioClip> screamHurtClip;
    public List<AudioClip> dieClip;
    public List<AudioClip> idleClip;
    private void Start()
    {
        if(myStepSource == null)
        myStepSource = GetComponent<AudioSource>();
    }

    public void WalkStep()
    {
        if (!myStepSource.isPlaying)
        {
            myStepSource.clip = walkStepClip[Random.Range(0, walkStepClip.Count)];
            myStepSource.Play();
        }
    }
    public void RunStep()
    {
        if (!myStepSource.isPlaying)
        {
            myStepSource.clip = runStepClip[Random.Range(0, runStepClip.Count)];
            myStepSource.Play();
        }
    }
    public void RangedAttack()
    {
        
            myRangedSource.clip = rangedAttackClip[Random.Range(0, rangedAttackClip.Count)];
            myRangedSource.Play();
        
    }

    public void MeleeAttack()
    {
        
            myMeleeSource.clip = meleeAttackClip[Random.Range(0, meleeAttackClip.Count)];
            myMeleeSource.Play();
        
    }
    public void ScreamAttack()
    {
            myStepSource.clip = screamAttackClip[Random.Range(0, screamAttackClip.Count)];
            myStepSource.Play();
    }
    public void HurtScream()
    {
        myStepSource.clip = screamHurtClip[Random.Range(0, screamHurtClip.Count)];
        myStepSource.Play();
    }
    public void DeathScream()
    {
        myStepSource.clip =dieClip[Random.Range(0, dieClip.Count)];
        myStepSource.Play();
    }
    public void IdleSound()
    {
        myStepSource.clip = idleClip[Random.Range(0, idleClip.Count)];
        myStepSource.Play();
    }
}
