using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSceneOf : MonoBehaviour
{
    public GameObject square;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void whenButtonCliked()
    {
        if (square.activeInHierarchy == true)
        {
            square.SetActive(false);
        }
        else
        {
            square.SetActive(true);
        }
    }
}

