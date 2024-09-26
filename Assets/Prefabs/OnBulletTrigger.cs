using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletTrigger : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Debug.Log(gameObject.name);
            FindObjectOfType<ScoreManager>().ScoreAndDifficltyHandler();
            Destroy(gameObject, 1);
        }
    }
}
