using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Throwable_Base : Weapon_Base
{
    protected override void UseWeapon()
    {
        base.UseWeapon();
    }
    protected override IEnumerator WeaponUsed()
    {
        yield return null;
    }
}
