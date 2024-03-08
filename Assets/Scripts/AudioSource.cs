using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioClip badFoodSound;
    public AudioClip goodFoodSound; // Asigna tu clip de sonido para la comida buena en el Editor de Unity
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("GoodFood"))
        {
            // Colisión con comida buena
            PlayGoodFoodSound();
            // Aquí puedes agregar lógica adicional, como incrementar un puntaje, destruir el objeto de comida, etc.
        }else if (other.CompareTag("BadFood"))
        {
            PlayBadFood();
        }
           
    }

    private void PlayGoodFoodSound()
    {
        if (goodFoodSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(goodFoodSound);
        }
    }
    private void PlayBadFood()
    {
        if (badFoodSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(badFoodSound);
        }
            
    }
}
