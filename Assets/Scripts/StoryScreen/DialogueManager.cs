using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class DialogueManager : MonoBehaviour
{
    private Queue<string> sentences;

    public Animator animator;
    public Text nameText;
    public Text dialogueText;
    public AudioManager audioManager;
    SceneLoader sceneLoad;

    public float textSpeed;
    //variable for array with listPopUps
    public GameObject[] titlePopUps;

    //private bool buttonPress;

    public GameObject continueButton;
    public GameObject startButton;
    public GameObject loadLevelButton;
    public GameObject endGameButton;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        continueButton.SetActive(false);
        loadLevelButton.SetActive(false);
        endGameButton.SetActive(false);

        //looping through popUps to disable them on start
        foreach (GameObject popUp in titlePopUps)
        {
            popUp.SetActive(false);
        }

        //buttonPress = false;
    }


    public void StartDialogue(Dialogue dialogue) //on start button press, the button will deactivate and the dialogue ui will apppear
    {
        startButton.SetActive(false);
        animator.SetBool("IsOpen", true);
        continueButton.SetActive(true);
        endGameButton.SetActive(true);

        nameText.text = dialogue.name;
        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence); 
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence() //on continue button press, this activates
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence(string sentence) //coroutine that controls text typing
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            if (!Input.GetKeyDown("space"))
            {
                dialogueText.text += letter;
                yield return new WaitForSeconds(textSpeed);

            }
            else
            {
                dialogueText.text = sentence;
                yield break;
            }
        }
    }

    //IEnumerator TypeSentence(string sentence)
    //{
    //    dialogueText.text = "";
    //    while (buttonPress == false)
    //    {
    //        foreach (char letter in sentence.ToCharArray())
    //        {
    //            dialogueText.text += letter;
    //            yield return new WaitForSeconds(textSpeed);
    //        }
    //        break;
    //    }

    //    dialogueText.text = sentence;
    //    buttonPress = false;
    //    yield break;
    //}

    IEnumerator loopThroughPopUps()
    {
        int timesRan = 0;
        //AudioSource aud = GetComponent<AudioSource>(); 

        //loop through popUps, and enable each one
        foreach (GameObject popUps in titlePopUps)
        {
            //speed up the pop-Up after the first 5
            if(timesRan < 4)
            {
                yield return new WaitForSeconds(1);
            }
            else if(timesRan < 7)
            {
                yield return new WaitForSeconds(0.5F);
            }else if(timesRan < 10)
            {
                yield return new WaitForSeconds(0.3F);
            }
            else
            {
                yield return new WaitForSeconds(0.1F);
            }

            popUps.SetActive(true);
            audioManager.playErrorSound();
            timesRan++;
            
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        StartCoroutine(loopThroughPopUps());
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
