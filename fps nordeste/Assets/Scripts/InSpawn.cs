using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InSpawn : MonoBehaviour
{
    public static bool ShopIsOpenned = false;
    public bool isSpawned;
    public GameObject buyMenuUI;

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Buy") && isSpawned)
        {
            if(ShopIsOpenned)
            {
                Cursor.lockState = CursorLockMode.None;
                
                buyMenuUI.SetActive(true);
                ShopIsOpenned = false;
                Time.timeScale = 0f;
            }
            
            else
            {
                buyMenuUI.SetActive(false);
                ShopIsOpenned = true;
                Time.timeScale = 1f;

                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }

    private void OnTriggerStay() 
    {
        isSpawned = true;
    }

    private void OnTriggerExit() 
    {
        isSpawned = false;
    }
}
