using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class reload : MonoBehaviour
{
    public GameObject sceneManager;
    public GameObject enemy1;
    string sceneName;
    // Use this for initialization
    void Start()
    {
        sceneManager = GameObject.FindGameObjectWithTag("transitionScene").gameObject;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void reloadSceneOne()
    {
        enemy1.GetComponent<enemy>().health = 5;
        sceneName = "mainGame";
        StartCoroutine(changeScene());
    }
    public void loadMainMenue()
    {
        enemy1.GetComponent<enemy>().health = 5;
        sceneName = "intro";
        StartCoroutine(changeScene());
    }
    IEnumerator changeScene()
    {
        sceneManager.GetComponent<sceneTransition>().changeScene();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(sceneName);
        Destroy(gameObject);
    }
    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}


