using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class pauseMenue : MonoBehaviour
{
    public GameObject pausemenue;
    public GameObject enemy1;
    // Use this for initialization
    void Start()
    {
        pausemenue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausemenue.SetActive(true);
        }
    }
    public void resume()
    {
        Time.timeScale = 1;
        pausemenue.SetActive(false);
    }
    public void reloadSameScene()
    {
        Time.timeScale = 1;
        pausemenue.SetActive(false);
        Scene sameScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(sameScene.name);
    }
    public void loadMainMenue()
    {
        Time.timeScale = 1;
        pausemenue.SetActive(false);
        enemy1.GetComponent<enemy>().health = 5;
        SceneManager.LoadScene("intro");
    }
    public void quitGame()
    {
        pausemenue.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("Quit");
        Application.Quit();
    }

}
