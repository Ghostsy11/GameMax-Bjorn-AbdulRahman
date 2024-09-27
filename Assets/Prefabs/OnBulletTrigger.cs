using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OnBulletTrigger : MonoBehaviour
{
    [SerializeField] private GameObject pickUp;
    private void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            FindObjectOfType<ScoreManager>().ScoreAndDifficltyHandler();
            Destroy(gameObject, 1);
        }
    }
}
