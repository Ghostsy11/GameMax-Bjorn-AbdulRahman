using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTypeTwo : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Transform player;
    [SerializeField] float rotationSpeed;
    [SerializeField] float enemySpeed;

    [SerializeField] private Collider[] detectedObjects;
    [SerializeField] private float overlapSphereRaduis;

    [SerializeField] AuidoPlayer auidoPlayer;
    [SerializeField] bool isDecteted;
    [SerializeField] bool isPlayFound;

    [SerializeField] AudioSource audioSource;

    [SerializeField] ParticleSystem playOnTouchingPlay;
    void Start()
    {
        StartCoroutine(playMusic());
    }

    // Update is called once per frame
    void Update()
    {

        MusicDectation();
        EnemyPumpiknRotating();
    }
    public void EnemyPumpiknRotating()
    {

        Vector3 direction = player.transform.position - transform.position;
        Quaternion rotationToPlayer = Quaternion.LookRotation(direction);
        rotationToPlayer.x = 0;
        rotationToPlayer.z = 0;
        transform.rotation = Quaternion.Lerp(transform.rotation, rotationToPlayer, rotationSpeed * Time.deltaTime);
    }

    public void FlyToPlayer()
    {
        Vector3 taget = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, taget, enemySpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        // When It tough player GameOver
        if (other.gameObject.tag == "Player")
        {
            Instantiate(playOnTouchingPlay, transform.position, Quaternion.identity);
            Debug.Log("GameOver");
        }
    }


    private void MusicDectation()
    {
        detectedObjects = Physics.OverlapSphere(transform.position, overlapSphereRaduis);

        foreach (var ObjectThatCollided in detectedObjects)
        {
            if (ObjectThatCollided.name != "Speler")
            {


            }
            else
            {

                isDecteted = true;
                isPlayFound = true;
                if (isDecteted && isPlayFound)
                {
                    FlyToPlayer();
                    if (!audioSource.isPlaying)
                    {
                        audioSource.Play();
                    }
                }

            }

        }

    }

    private IEnumerator playMusic()
    {
        if (isDecteted == false)
        {
            auidoPlayer.PlayShootingClip();
        }
        yield return null;
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, overlapSphereRaduis);
    }

}
