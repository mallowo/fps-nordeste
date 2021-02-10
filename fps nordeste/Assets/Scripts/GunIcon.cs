 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunIcon : MonoBehaviour
{
    public WeaponSwitching switching;
    public Image icon1;
    public Image icon2;
    public Image icon3;
    
    // Update is called once per frame
    void Update()
    {
        icon1.color = new Color(icon1.color.r, icon1.color.g, icon1.color.b, 0.5f); 
        icon2.color = new Color(icon2.color.r, icon2.color.g, icon2.color.b, 0.5f); 
        icon3.color = new Color(icon3.color.r, icon3.color.g, icon3.color.b, 0.5f); 

        switch (switching.selectedWeapon)
        {
            case 0:
                icon1.color = new Color(icon1.color.r, icon1.color.g, icon1.color.b, 1f); 
                break;   

            case 1:
                icon2.color = new Color(icon2.color.r, icon2.color.g, icon2.color.b, 1f); 
                break;

            case 2:
                icon3.color = new Color(icon3.color.r, icon3.color.g, icon3.color.b, 1f); 
                break;
        }
        
    }
}
