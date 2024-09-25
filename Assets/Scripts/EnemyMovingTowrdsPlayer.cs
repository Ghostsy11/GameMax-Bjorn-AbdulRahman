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



    public int GetHealth(int _enemyHealth)
    {
        enemyHealth = _enemyHealth;
        return enemyHealth;
    }
    public IEnumerator MoveToPlayer()
    {
        Vector3 taget = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, taget, enemySpeed * Time.deltaTime);
        yield return new WaitForFixedUpdate();
        StartCoroutine(MoveToPlayer());
    }

}
