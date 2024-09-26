using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon_PickUp : MonoBehaviour
{
    public static Weapon_PickUp Instance;
    private Transform weaponSpot;
    [SerializeField] private List<GameObject> weapons = new();
    //spawnable weapons with scripts
    [SerializeField] private List<GameObject> weaponsPrefabsPlayer;
    private GameObject player;
    private int selectedWeapon = 0;
    [SerializeField] private float rotationSpeed = 5;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float moveAmmount = 20;
    private Transform targetPosition;
    private Transform startPosition;
    void Start()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
        player = SC_PlayerMovement.Instance.gameObject;
        weaponSpot = Camera.main.transform.GetChild(1);
        selectedWeapon = UnityEngine.Random.Range(0, weapons.Count);
        Instantiate(weapons[selectedWeapon], transform.position, quaternion.identity, transform);
        startPosition = transform;
        //targetPosition.position += new Vector3(0, moveAmmount, 0);
        //Debug.Log(transform.position);
        //Debug.Log(targetPosition.position.y);
        //StartCoroutine(MovePickUp(targetPosition));
    }
    private void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    private IEnumerator MovePickUp(Transform target)
    {
        if (target.position == transform.position)
        {
            Debug.Log(target.position.y);
            Debug.Log(transform.position.y);
        }
        while (transform.position != target.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, moveSpeed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
            Debug.Log("moving");
        }
        Debug.Log("Hallo");
        if (target.position.y > startPosition.position.y)
        {
            target.position = new Vector3(startPosition.position.x, startPosition.position.y - moveAmmount, startPosition.position.z);
        }
        else
        {
            target.position = new Vector3(startPosition.position.x, startPosition.position.y + moveAmmount, startPosition.position.z);
        }
        StartCoroutine(MovePickUp(target));
    }
    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log(collider);
        if (collider.gameObject == player.gameObject && weaponSpot.childCount <= 0)
        {
            Instantiate(weaponsPrefabsPlayer[selectedWeapon], weaponSpot.position, weaponSpot.rotation, weaponSpot);
            Instance = null;
            Destroy(gameObject);
        }
    }
}