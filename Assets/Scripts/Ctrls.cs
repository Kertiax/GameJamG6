using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ctrls : MonoBehaviour
{
   
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void LoadSounds(AudioSource audioSource)
    {
        audioSource.PlayOneShot(audioSource.clip);
    }

    public void SetPanels(bool panel)
    {
        if (panel == false) 
        {
            gameObject.SetActive(true);
        }
    }
}
