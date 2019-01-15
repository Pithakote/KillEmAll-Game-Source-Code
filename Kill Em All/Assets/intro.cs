using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class intro : MonoBehaviour {
    public GameObject canvas;
	// Use this for initialization
	void Start () {
        canvas.SetActive(false);
	}
    private void Update()
    {
        if (canvas.active)
        {
            if (Input.anyKey)
            {
                SceneManager.LoadScene("tutorial");
            }
        }
    }
    // Update is called once per frame


    public void introIns()
    {
        canvas.SetActive(true);
        
    }
}
