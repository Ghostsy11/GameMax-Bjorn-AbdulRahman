using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_RPG : Bullet {
    [SerializeField]private GameObject explosion;

    protected override void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Instantiate(explosion);
            Destroy(gameObject);
        }
    }
}
