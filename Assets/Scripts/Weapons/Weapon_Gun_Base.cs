using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun_Base : Weapon_Base
{
    // Start is called before the first frame update
    [SerializeField] protected GameObject bulletPrefab;
    protected Transform bulletSpawnPoint;
    [SerializeField] private int kickBack;
    protected override void Start()
    {
        base.Start();
        bulletSpawnPoint = Camera.main.transform.GetChild(2);
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }
    protected override void UseWeapon()
    {
        base.UseWeapon();
        Shoot();
    }

    protected virtual void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
    }

    protected override IEnumerator WeaponUsed()
    {
        if (useSound != null)
        {
            useSound.Play();
        }
        int i = kickBack / 5;
        while (i > 0)
        {
            i--;
            yield return new WaitForFixedUpdate();
            transform.Rotate(10, 0, 0);
        }
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
