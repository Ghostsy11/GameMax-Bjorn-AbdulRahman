using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public abstract class Weapon_Base : MonoBehaviour
{
    [SerializeField]protected Animation useAnim;
    [SerializeField]protected Animation pickUpAnim;
    [SerializeField]protected Animation dropAnim;
    [SerializeField]protected KeyCode useKey = KeyCode.Mouse0;
    protected GameObject player;
    protected Camera cam;
    [SerializeField]protected AudioSource useSound;
    protected bool used = false;
    protected virtual void Start(){
        player = GameObject.Find("Player");
        cam = Camera.main;
        if (pickUpAnim != null){
            pickUpAnim.Play();
        }
    }
    protected virtual void Update(){
        if(Input.GetKeyDown(useKey) && !used){
            UseWeapon();
        }
    }
    //check if dropanim is not null then playe anim and destroy weapon
    //play use anim if not null and start weaponused function
    async protected virtual void UseWeapon(){
        used = true;
        if (useAnim != null){
            useAnim.Play();
            await Task.Delay((int)(useAnim.clip.length/1000));
        }
        if (useSound != null){
            useSound.Play();
        }
        StartCoroutine(WeaponUsed());
    }
    protected abstract IEnumerator WeaponUsed();
}
