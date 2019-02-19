using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class intro : MonoBehaviour {
    public GameObject canvas;
    public GameObject sceneManager;
    // Use this for initialization
    void Start () {
        sceneManager = GameObject.FindGameObjectWithTag("transitionScene").gameObject;

        canvas.SetActive(false);
	}
    private void Update()
    {
        if (canvas.active)
        {
            if (Input.anyKey)
            {
                StartCoroutine(changeScene());
                
            }
        }
    }
    // Update is called once per frame
    IEnumerator changeScene()
    {
        sceneManager.GetComponent<sceneTransition>().changeScene();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("tutorial");
        Destroy(gameObject);
    }

    public void introIns()
    {
        canvas.SetActive(true);
        
    }
}
