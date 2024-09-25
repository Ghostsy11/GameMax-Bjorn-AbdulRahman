using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Patrolling : MonoBehaviour
{
    [SerializeField] EnemyMovingTowrdsPlayer whenPlayerFound;
    [SerializeField] bool isFound;
    bool rotating = false;

    [SerializeField] Transform[] points;
    [SerializeField] float speedToThePoint;
    private int current;

    [SerializeField] Collider[] detectedObjects;
    [SerializeField] float overlapSphereRaduis;

    [SerializeField] GameObject player;
    [SerializeField] private float rotationSpeed = 5;

    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody Rigidbodyrb;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {

        }
        CheckingObjectsAround();
    }


    private void MoveToThePoints()
    {
        if (!isFound && transform.position != points[current].position)
        {
            transform.position = Vector3.MoveTowards(transform.position, points[current].position, speedToThePoint * Time.deltaTime);
        }
        else
        {
            current = (current + 1) % points.Length;
        }
    }

    private void CheckingObjectsAround()
    {

        detectedObjects = Physics.OverlapSphere(transform.position, overlapSphereRaduis);
        if (detectedObjects.Length > 0 && !isFound)
        {
            foreach (var ObjectThatCollided in detectedObjects)
            {
                if (ObjectThatCollided.name != "Speler")
                {
                    MoveToThePoints();

                }
                else
                {
                    isFound = true;
                    rotating = true;
                    Coroutine waiting = StartCoroutine(Stress());
                }

            }

        }

    }


    private void DoubleCheck()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overlapSphereRaduis);
    }

    private IEnumerator RotateToPlayer()
    {


        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotationToPlayer = Quaternion.LookRotation(direction);
        rotationToPlayer.x = 0;
        rotationToPlayer.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlayer, rotationSpeed * Time.deltaTime);
        yield return new WaitForFixedUpdate();
        StartCoroutine(RotateToPlayer());

    }


    IEnumerator Stress()
    {


        yield return new WaitForSeconds(1);
        StartCoroutine(RotateToPlayer());
        yield return new WaitForSeconds(1);
        Rigidbodyrb.AddForce(Vector3.up * jumpForce);
        //Springen
        yield return new WaitForSeconds(3);
        StartCoroutine(whenPlayerFound.MoveToPlayer());
        // Play music

    }




}
