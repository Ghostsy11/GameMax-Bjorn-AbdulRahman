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

    // UI GameOverScript
    public GameObject panel;
    [SerializeField] ScoreManager scoreManager;

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
        IEnumerator waitCoupleOfSecounds()
        {
            zombieSounds.PlayZombieSlap();
            collision.gameObject.SetActive(false);
            yield return new WaitForSeconds(2.2f);
            scoreManager.LoadGameOverScreen();
            scoreManager.ResetScore();
        }

        if (collision.gameObject.tag == "Player")
        {
            animationContoller.PlayAttackWithTwoHands();
            StartCoroutine(waitCoupleOfSecounds());

        }
    }


    public void SetGameOverPanelOn()
    {
        panel.SetActive(true);
    }

    public void SetGameOverPanelOff()
    {
        panel.SetActive(false);
    }

}
