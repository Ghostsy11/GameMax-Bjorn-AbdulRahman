using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyMovingTowrdsPlayer : MonoBehaviour
{
    // Start is called before the first frame update

    // Player Object reference
    [SerializeField] GameObject player;

    // Speed of the enemy moving towards player
    [SerializeField] float enemySpeed;
    // enemy  health propries
    [SerializeField] int enemyHealth = 100;

    [SerializeField] AudioSource zombieFootSteps;
    [SerializeField] AuidoPlayer zombieSounds;

    [SerializeField] AnimationContoller animationContoller;


    public int GetHealth(int _enemyHealth)
    {
        enemyHealth = _enemyHealth;
        return enemyHealth;
    }
    public IEnumerator MoveToPlayer()
    {
        if (!zombieFootSteps.isPlaying)
        {

            zombieFootSteps.Play();
        }
        Vector3 taget = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, taget, enemySpeed * Time.deltaTime);
        yield return new WaitForFixedUpdate();
        StartCoroutine(MoveToPlayer());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animationContoller.PlayAttackWithTwoHands();
            StartCoroutine(waitCoupleOfSecounds());

        }
    }

    IEnumerator waitCoupleOfSecounds()
    {
        yield return new WaitForSeconds(1.5f);
        zombieSounds.PlayZombieSlap();

    }

}
