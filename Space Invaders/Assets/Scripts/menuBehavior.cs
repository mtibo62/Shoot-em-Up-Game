﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Screen.fullScreen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toGame()
    {
       SceneManager.LoadScene("Main Scene");
    }

    public void toControls()
    {
        SceneManager.LoadScene("Control Scene");
    }
}
