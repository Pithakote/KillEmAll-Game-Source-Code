using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraShake : MonoBehaviour {

    public Animator cameraAnim;
    // Use this for initialization
    private void Start()
    {
        //cameraAnim.SetBool("shake", false);
    }
    public void CamShake()
    {
        cameraAnim.SetTrigger("shake");
    }
}
