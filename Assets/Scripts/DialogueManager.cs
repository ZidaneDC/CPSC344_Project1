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

    public float textSpeed;

    //private bool buttonPress;

    public GameObject continueButton;
    public GameObject startButton;
    public GameObject loadLevelButton;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        continueButton.SetActive(false);
        loadLevelButton.SetActive(false);
        
        //buttonPress = false;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown("space"))
    //    {
    //        buttonPress = true;
    //        Debug.Log("space key down.");
    //    }
    //}

    public void StartDialogue(Dialogue dialogue) //on start button press, the button will deactivate and the dialogue ui will apppear
    {
        startButton.SetActive(false);
        animator.SetBool("IsOpen", true);
        continueButton.SetActive(true);

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

    void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        loadLevelButton.SetActive(true);
    }
}
