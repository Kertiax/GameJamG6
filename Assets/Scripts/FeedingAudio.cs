using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedingAudio : MonoBehaviour
{
   
    public AudioClip goodFoodSound;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
       
        if (other.CompareTag("Player"))
        {
            PlayGoodFoodSound();
        }

    }

    private void PlayGoodFoodSound()
    {
        if (goodFoodSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(goodFoodSound);
        }
    }
  
}
