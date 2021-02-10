using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public Target target;
    public Text healthText;

    // Update is called once per frame
    void Update()
    {
        healthText.text = "HEALTH: " + target.health;
    }
} 
