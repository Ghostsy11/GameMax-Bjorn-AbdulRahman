using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Weapon_PickUp : MonoBehaviour
{
    public static Weapon_PickUp Instance;
    private Transform weaponSpot;
    [SerializeField]private List<GameObject> weapons = new();
    //spawnable weapons with scripts
    [SerializeField]private List<GameObject> weaponsPrefabsPlayer;
    private GameObject player;
    private int selectedWeapon = 0;
    void Start()
        {
        if (Instance != null) 
        { 
            Destroy(this);
        } 
        else 
        { 
            Instance = this; 
        }    
        player = SC_PlayerMovement.Instance.gameObject;
        weaponSpot = Camera.main.transform.GetChild(1);
        selectedWeapon = UnityEngine.Random.Range(0, weapons.Count);
        Instantiate(weapons[selectedWeapon], transform.position, quaternion.identity, transform);
        Debug.Log(player);
    }
    private void OnTriggerEnter(Collider collider){
        Debug.Log(collider);
        if(collider.gameObject == player    && weaponSpot.childCount <= 0){
            Instantiate(weaponsPrefabsPlayer[selectedWeapon], weaponSpot.position, weaponSpot.rotation, weaponSpot);
            Destroy(gameObject);
        }
    }
}