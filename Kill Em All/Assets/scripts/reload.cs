using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reload : MonoBehaviour
{

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
        SceneManager.LoadScene("mainGame");
    }
    public void loadMainMenue()
    {
        SceneManager.LoadScene("intro");
    }
    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}


