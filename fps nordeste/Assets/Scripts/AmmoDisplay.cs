using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour
{
    public WeaponSwitching switching;
    public Gun gun1;
    public Gun gun2;
    public Gun gun3;
    public Text ammoText;

    // Update is called once per frame
    void Update()
    {
        switch (switching.selectedWeapon)
        {
            case 0:
                ammoText.text = "AMMO: " + gun1.currentAmmo + " / " + gun1.maxAmmo;
                break;   

            case 1:
                ammoText.text = "AMMO: " + gun2.currentAmmo + " / " + gun2.maxAmmo;
                break;

            case 2:
                ammoText.text = "AMMO: " + gun3.currentAmmo + " / " + gun3.maxAmmo;
                break;
        }


    }
}
