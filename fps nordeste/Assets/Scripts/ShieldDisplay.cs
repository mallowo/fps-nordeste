using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShieldDisplay : MonoBehaviour
{
    public Target target;
    public Text shieldText;
    // Update is called once per frame
    void Update()
    {
         shieldText.text = "SHIELD: " + target.shield;
    }
}
