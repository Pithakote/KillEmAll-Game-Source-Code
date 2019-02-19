using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomiseMusic : MonoBehaviour {
    public AudioSource source;
    public AudioClip[] musicArray;
    private AudioClip clip;
    // Use this for initialization
    void Start () {
        int index = Random.Range(0, musicArray.Length);
        clip = musicArray[index];
        source.clip = clip;
        source.Play();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
