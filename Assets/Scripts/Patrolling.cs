using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.GraphicsBuffer;

public class Patrolling : MonoBehaviour
{
    [SerializeField] EnemyMovingTowrdsPlayer whenPlayerFound;
    [SerializeField] bool isFound;

    [SerializeField] Transform[] points;
    [SerializeField] float speedToThePoint;
    private int current;

    [SerializeField] Collider[] detectedObjects;
    [SerializeField] float overlapSphereRaduis;

    [SerializeField] GameObject player;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] float _turnSpeed;

    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody Rigidbodyrb;

    [SerializeField] AnimationContoller animationContoller;

    [SerializeField] AuidoPlayer auidoclips;

    void Update()
    {

        CheckingObjectsAround();
    }


    private void MoveToThePoints()
    {
        if (!isFound && transform.position != points[current].position)
        {
            FaceTargetPoints();
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
                    animationContoller.DontPlayRunning();
                    isFound = true;
                    Coroutine waiting = StartCoroutine(Stress());
                }

            }

        }

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
        //Rotate To Player
        animationContoller.PlayTurningToPlayer();
        yield return new WaitForSeconds(3);
        StartCoroutine(RotateToPlayer());
        auidoclips.PlayZombieYellingSound();
        yield return new WaitForSeconds(3);
        //Springen
        animationContoller.DontTurningToPlayer();
        animationContoller.PlayZombieJump();
        //Rigidbodyrb.AddForce(Vector3.up * jumpForce);

        // running to enemy
        yield return new WaitForSeconds(2);
        animationContoller.PlayRunning();
        StartCoroutine(whenPlayerFound.MoveToPlayer());
        // Play music

    }

    private void FaceTargetPoints()
    {

        Vector3 direction = (points[current].position - transform.position).normalized;
        Quaternion LookRotation = Quaternion.LookRotation(transform.position, points[current].position);
        LookRotation.x = 0;
        LookRotation.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, LookRotation, _turnSpeed * Time.deltaTime);

    }

    //new Vector3(direction.x, 0, direction.z)
}
