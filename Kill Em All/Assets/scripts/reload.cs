﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reload : MonoBehaviour
{
    public GameObject enemy1;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reloadSceneOne()
    {
        enemy1.GetComponent<enemy>().health = 5;
        SceneManager.LoadScene("mainGame");
    }
    public void loadMainMenue()
    {
        enemy1.GetComponent<enemy>().health = 5;
        SceneManager.LoadScene("intro");
    }
    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}


