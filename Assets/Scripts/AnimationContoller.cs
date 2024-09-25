using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationContoller : MonoBehaviour
{
    [SerializeField] Animator enemyAnimator;

    const string zombieRuning = "ZombieRunning";
    const string ZombieTurning = "ZombieTurning";
    const string Yelling = "Yelling";
    const string ZombieJump = "ZombieJump";
    const string HandsAttack = "HandsAttack";



    public void PlayRunning()
    {
        enemyAnimator.SetBool(zombieRuning, true);
    }
    public bool DontPlayRunning()
    {
        enemyAnimator.SetBool(zombieRuning, false);

        return false;

    }

    public void PlayTurningToPlayer()
    {
        enemyAnimator.SetBool(ZombieTurning, true);
    }
    public void DontTurningToPlayer()
    {
        enemyAnimator.SetBool(zombieRuning, false);

    }

    public void PlayZombieJump()
    {
        enemyAnimator.SetBool(ZombieJump, true);

    }
    public void DontZombieJump()
    {
        enemyAnimator.SetBool(ZombieJump, false);

    }

    public void PlayAttackWithTwoHands()
    {
        enemyAnimator.SetBool(HandsAttack, true);
    }
    public void DontAttackWithTwoHands()
    {
        enemyAnimator.SetBool(HandsAttack, false);

    }






}
