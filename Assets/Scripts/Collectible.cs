//CPCS 344 - Level Design II, Chapman University, Fall 21
//Script reference : https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html 
using UnityEngine;
using UnityEngine.UI;

public class Collectible : Object
{
    public AudioManager audioManager;

    private void Update()
    {
        if (canInteract)
        {
            //wait for player input, upon which the object will be destroyed and the object added to player inventory
            if (Input.GetKeyDown(KeyCode.E))
            {
                //send information to player inventory
                audioManager.playPickupSound();
                playerInventory.inventory.Add(objectType);
                canInteract = false;
                //hide ui
                uiManager.HideInteractionPrompt();
                uiManager.SetLogText(objectType + " added to inventory.");
                Destroy(gameObject);
            }
        }
    }
}
