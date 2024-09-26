using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun_RPG : Weapon_Gun_Base
{
    [SerializeField]private float knockBackForce;
    protected override void Shoot()
    {
        KnockBack();
        base.Shoot();
    }

    private void KnockBack()
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.forward * knockBackForce);
    }
}
