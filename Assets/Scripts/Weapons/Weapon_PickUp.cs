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
        weaponSpot = player.transform.Find("weaponSpot");
        selectedWeapon = UnityEngine.Random.Range(0, weapons.Count);
        Instantiate(weapons[selectedWeapon], transform.position, quaternion.identity, transform);
    }
    private void OnTriggerEnter(Collider collider){
        if(collider == player && weaponSpot.childCount <= 0){
            Instantiate(weapons[selectedWeapon], weaponSpot.position, weaponSpot.rotation, weaponSpot);
            Destroy(gameObject);
        }
    }
}
