using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gotmaingame : MonoBehaviour {
    public GameObject sceneManager;
    // Use this for initialization
    void Start() {
        sceneManager = GameObject.FindGameObjectWithTag("transitionScene").gameObject;

    }

    // Update is called once per frame
    void Update() {

    }

    public void continueScene()
       {
        StartCoroutine(changeScene());

        
       }
    IEnumerator changeScene()
    {
        sceneManager.GetComponent<sceneTransition>().changeScene();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("mainGame");
        Destroy(gameObject);
    }
}
