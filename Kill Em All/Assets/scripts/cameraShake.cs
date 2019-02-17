using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {

    public Animator cameraAnim;
    // Use this for initialization
    public AudioClip [] music;
    public AudioSource damageSound;
    private void Start()
    {
        
        //cameraAnim.SetBool("shake", false);
    }
    public void CamShake()
    {
        damageSound.clip = music[0];
        damageSound.Play();
        cameraAnim.SetTrigger("shake");
    }
    public void CamShake2()
    {
        damageSound.clip = music[1];
        damageSound.Play();
        cameraAnim.SetTrigger("shake");
    }

    public void IntroBoss()
    {
        cameraAnim.SetTrigger("introShake");
        StartCoroutine(idleTrigger());
    }

    IEnumerator idleTrigger()
    {
        yield return new  WaitForSeconds(6);
        cameraAnim.SetTrigger("idle");
    }
}
