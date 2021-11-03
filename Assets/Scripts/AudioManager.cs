using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip error;
    public AudioClip success;
    public AudioClip pickup;

    public void playErrorSound()
    {
        audioSource.PlayOneShot(error, 3);
    }

    public void playSuccessSound()
    {
        audioSource.PlayOneShot(success, 2);
    }

    public void playPickupSound()
    {
        audioSource.PlayOneShot(pickup, 2);
    }
}
