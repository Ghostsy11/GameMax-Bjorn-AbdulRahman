using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun_Base : Weapon_Base
{
    // Start is called before the first frame update
    [SerializeField]protected GameObject bulletPrefab;
    [SerializeField]protected Transform bulletSpawnPoint;
    [SerializeField]private int kickBack;
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

    protected virtual void Shoot()
    {
        //Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    protected override IEnumerator WeaponUsed()
    {
        int i = kickBack/10;
        while(i > 0){
            i--;
            yield return new WaitForFixedUpdate();
            transform.Rotate(10,0,0);
        }
        Destroy(gameObject);
    }
}
