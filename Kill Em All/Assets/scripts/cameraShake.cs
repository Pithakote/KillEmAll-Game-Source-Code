using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {

    public Animator cameraAnim;
    // Use this for initialization
    public AudioClip music;
    public AudioSource damageSound;
    private void Start()
    {
        damageSound.clip = music;
        //cameraAnim.SetBool("shake", false);
    }
    public void CamShake()
    {
        damageSound.Play();
        cameraAnim.SetTrigger("shake");
    }
}
