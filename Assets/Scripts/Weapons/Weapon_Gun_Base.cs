using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun_Base : Weapon_Base
{
    // Start is called before the first frame update
    [SerializeField]protected GameObject bulletPrefab;
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void UseWeapon(){
        base.UseWeapon();
        Shoot();
    }

    private void Shoot()
    {
        Instantiate(bulletPrefab);
    }

    protected override IEnumerator WeaponUsed()
    {
        if (dropAnim != null){
                    dropAnim.Play();
        yield return new WaitForSeconds(dropAnim.clip.length);
        }
        Destroy(gameObject);
    }
}
