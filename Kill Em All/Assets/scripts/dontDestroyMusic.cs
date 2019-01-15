using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class dontDestroyMusic : MonoBehaviour
{

    private static dontDestroyMusic instance = null;
    private string sceneName;
    public static dontDestroyMusic Instance
    {
        get { return instance; }
    }
    // Use this for initialization
    void Start()
    {
        Cursor.visible = true;
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }
    private void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("music");
        if (obj.Length > 1)
        {
            Destroy(this.gameObject);
        }

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
