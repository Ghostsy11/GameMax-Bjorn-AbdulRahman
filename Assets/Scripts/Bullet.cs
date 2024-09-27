using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    protected Rigidbody rb;
    protected GameObject player;
    [SerializeField] private float bulletSpeed = 10;
    void Start()
    {
        player = SC_PlayerMovement.Instance.gameObject;
        rb = GetComponent<Rigidbody>();
        rb.AddRelativeForce(Vector3.forward * bulletSpeed);
    }
    protected virtual void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("Player"))
        {
            Debug.Log("dead");
            Destroy(gameObject, 0.1f);
        }
    }
}
