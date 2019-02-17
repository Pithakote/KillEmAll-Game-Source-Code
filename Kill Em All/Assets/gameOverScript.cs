using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class gameOverScript : MonoBehaviour
{
    int wavenumber = 0;
    public TMP_Text scoretext;
    
    // Use this for initialization
    void Start()
    {
        //dontDestroyMusic.Instance.gameObject.GetComponent<AudioSource>().Pause();
      //  Destroy(GameObject.Find("audio"));
        wavenumber = PlayerPrefs.GetInt("Score");

    }
    void OnGUI()
    {

    }
    // Update is called once per frame
    void Update()
    {
        scoretext.text = "Wave Number: " + wavenumber.ToString();

    }
}
