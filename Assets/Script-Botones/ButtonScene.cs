using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;



public class ButtonScene : MonoBehaviour
{
    private bool isPause;
    [SerializeField] GameObject panelPause;
    bool panelstate;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            isPause = !isPause;
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (isPause)
        {
            Time.timeScale = 0;
            panelPause.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            panelPause.SetActive(false);
        }
    }

    public void CerrarInstrucciones(GameObject Panels)
    {
        panelstate = !panelstate;
        if (panelstate)
        {
            
                Panels.SetActive(true);
            
        }
        else
        {
            
                Panels.SetActive(false);
            
        }
    }

}
