using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;

public abstract class Weapon_Base : MonoBehaviour
{
    protected Animation useAnim;
    protected Animation pickUpAnim;
    protected Animation dropAnim;
    protected KeyCode useKey = KeyCode.Mouse0;
    protected GameObject player;
    protected virtual void Start(){
        player = GameObject.Find("Player");
        if (pickUpAnim != null){
            pickUpAnim.Play();
        }
    }
    protected virtual void Update(){
        if(Input.GetKey(useKey)){
            UseWeapon();
        }
    }
    //check if dropanim is not null then playe anim and destroy weapon
    //play use anim if not null and start weaponused function
    async protected virtual void UseWeapon(){
        if (useAnim != null){
            useAnim.Play();
            await Task.Delay((int)(useAnim.clip.length/1000));
        }
        StartCoroutine(WeaponUsed());
    }
    protected abstract IEnumerator WeaponUsed();
}
