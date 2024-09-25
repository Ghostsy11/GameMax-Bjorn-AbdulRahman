using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{

    [SerializeField] Rigidbody rp;
    [SerializeField] private float jumpForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rp.AddForce(Vector3.up * jumpForce);
        }
    }
}
