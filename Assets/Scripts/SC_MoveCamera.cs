using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_MoveCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    void Update()
    {
        transform.position = target.position;
    }
}
