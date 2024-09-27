using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBulletTrigger : MonoBehaviour
{
    [SerializeField] private GameObject pickUp;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Instantiate(pickUp, transform.position, Quaternion.identity);
            FindObjectOfType<ScoreManager>().ScoreAndDifficltyHandler();
            Destroy(gameObject, 1);
        }
    }
}
