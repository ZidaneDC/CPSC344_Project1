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
        audioSource.PlayOneShot(error, 1);
    }

    public void playSuccessSound()
    {
        audioSource.PlayOneShot(success, 1);
    }

    public void playPickupSound()
    {
        audioSource.PlayOneShot(pickup, 1);
    }
}
