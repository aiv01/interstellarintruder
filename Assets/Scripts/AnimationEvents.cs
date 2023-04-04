using UnityEngine;
using UnityEngine.SceneManagement;

public class AnimationEvents : MonoBehaviour
{
    #region Player Animation Event
    public void MeleeAttackStart()
    {

    }

    public void MeleeAttackEnd()
    {

    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOverScene");
    }
    #endregion

    #region Enemy Animation Event
    public void ActivateShield()
    {

    }

    public void DamageMelee()
    {
        
    }

    public void MeleeAttack()
    {

    }

    public void StartAttack()
    {

    }

    public void EndAttack()
    {

    }

    public void PlayStep()
    {

    }

    public void Shoot()
    {

    }
    #endregion
}
