using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class Weapon_Gun_Revolver : Weapon_Gun_Base
{
    int loadedCartridge = 0;
    int currentCartridge = 0;
    private Transform cartridge;
    private float realoadTime;
    private bool reloading = false;
    [SerializeField]private AudioSource emptyRound;
    protected override void Start()
    {
        base.Start();
        loadedCartridge = UnityEngine.Random.Range(0,6);
        Debug.Log(loadedCartridge);
        cartridge = transform.GetChild(1);
    }
    protected override void UseWeapon()
    {
        if (reloading) return;
        if(currentCartridge == loadedCartridge)
        {
            base.UseWeapon();
        }
        else
        {
            currentCartridge++;
            emptyRound.Play();
            StartCoroutine(Cartridge(60));
        }
        Debug.Log(currentCartridge);
    }
    private IEnumerator Cartridge(float rotation){
        reloading = true;
        while(rotation > 0){
            rotation--;
            yield return new WaitForFixedUpdate();
            cartridge.RotateAround(cartridge.GetChild(0).position,Vector3.forward, 60 * Time.deltaTime);
        }
        reloading = false;
    }
}
