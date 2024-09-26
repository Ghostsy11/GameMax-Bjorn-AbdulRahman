using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_Gun_Revolver : Weapon_Gun_Base
{
    int loadedCartridge = 0;
    int currentCartridge = 0;
    protected override void Start()
    {
        base.Start();
        loadedCartridge = Random.Range(0,6);
    }
    protected override void UseWeapon()
    {
        if(currentCartridge == loadedCartridge)
        {
            base.UseWeapon();
        }
        else
        {
            currentCartridge++;
        }
                    Debug.Log(currentCartridge);
                    Debug.Log(loadedCartridge);
    }
}
