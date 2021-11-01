//CPCS 344 - Level Design II, Chapman University, Fall 21
//Script reference : https://docs.unity3d.com/ScriptReference/Collider.OnTriggerEnter.html 
using UnityEngine;
using UnityEngine.UI;

public class Collectible : MonoBehaviour
{
    public string objectType;
    public GameObject collectionPrompt;
    public AudioManager audioManager;

    private PlayerInventory playerInventory;
    private bool canCollect;

    private void Start()
    {
        collectionPrompt.SetActive(false);
        canCollect = false;
    }

    private void Update()
    {
        if (canCollect)
        {
            //wait for player input, upon which the object will be destroyed and the object added to player inventory
            if (Input.GetKeyDown(KeyCode.E))
            {
                //send information to player inventory
                audioManager.playPickupSound();
                playerInventory.inventory.Add(objectType);
                Debug.Log(objectType + " added to inventory.");
                //hide ui
                HidePrompt();
                Destroy(gameObject);
            }
        }
    }
    //OLD: Upon a collider hitting the trigger, this collectible will be destroyed
    //updated version will display a UI popup upon player entering the trigger area
    private void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Player")
        {
            //Debug.Log("Entered object range.");
            canCollect = true;
            //display ui
            DisplayPrompt();
            //find player script
            playerInventory = other.gameObject.GetComponent<PlayerInventory>();
            //make sure script was obtained
            //if (playerInventory != null)
            //{
            //    Debug.Log("Obtained player inventory.");
            //}
        }
    }


    private void OnTriggerExit(Collider other)
    {
        playerInventory = null;
        HidePrompt();
    }

    private void DisplayPrompt()
    {
        collectionPrompt.SetActive(true);
    }

    private void HidePrompt()
    {
        collectionPrompt.SetActive(false);
    }
}
