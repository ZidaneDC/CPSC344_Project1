using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteController : MonoBehaviour
{
    public UIManager manager;

   public void onButtonPress()
    {
        manager.ShowNotePopUp();
    }
}
