using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Weapon_Gun_Revolver : Weapon_Gun_Base
{
    int loadedCartridge = 0;
    int currentCartridge = 0;
    private Transform cartridge;
    private bool reloading = false;
    [SerializeField]private AudioSource emptyRound;
    protected override void Start()
    {
        base.Start();
        loadedCartridge = UnityEngine.Random.Range(0,6);
        cartridge = transform.GetChild(1);
    }
    protected override void UseWeapon()
    {
        if (!reloading){
            if(currentCartridge == loadedCartridge)
            {
                base.UseWeapon();
            }
            else
            {
                currentCartridge++;
                if (emptyRound != null){
                    emptyRound.Play();
                }
                StartCoroutine(Cartridge(60));
            }
        }
    }
    private IEnumerator Cartridge(float rotation){
        reloading = true;
        while(rotation > 0){
            rotation--;
            yield return new WaitForFixedUpdate();
            cartridge.RotateAround(cartridge.GetChild(0).position, cartridge.forward, 60 * Time.deltaTime);
        }
        reloading = false;
    }
}
