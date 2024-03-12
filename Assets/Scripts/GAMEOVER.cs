using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GAMEOVER : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Restart(string scene1)
    {
        SceneManager.LoadScene(scene1);
    }

    public void ExitCurGame(string scene2)
    {
        SceneManager.LoadScene(scene2);
    }
}
