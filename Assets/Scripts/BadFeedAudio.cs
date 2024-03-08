using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadFeedAudio : MonoBehaviour
{
    public AudioClip badFoodSound;
    private AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Colisión con comida buena
            PlayBadFood();
            // Aquí puedes agregar lógica adicional, como incrementar un puntaje, destruir el objeto de comida, etc.
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
