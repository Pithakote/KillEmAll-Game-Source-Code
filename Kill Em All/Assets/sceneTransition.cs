using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class sceneTransition : MonoBehaviour {
    public Animator transitionAnim;
    public Animator transitionAnim2;
    // Use this for initialization
    void Start () {
        
    }
    public void changeScene()
    {
        transitionAnim.SetTrigger("end");
        transitionAnim2.SetTrigger("end");
    }
   
    // Update is called once per frame
    void Update () {
		
	}
}
