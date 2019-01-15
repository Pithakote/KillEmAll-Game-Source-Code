using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooterScript : MonoBehaviour {


    public float offset;
    public GameObject bullet;
    public Transform shootFrom;
    public Transform secondShooter;
    public Transform thirdShooter;
    public Transform fourthShooter;
    private float delayShot;
    public float startDelayShot;
    
    private cameraShake shake;

    // Use this for initialization
    void Start () {
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 theLength = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(theLength.y, theLength.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (delayShot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
               // shake.CamShake();
                Instantiate(bullet, shootFrom.position, transform.rotation);
               
                delayShot = startDelayShot;
                
            }
        }
        else
        {
            delayShot -= Time.deltaTime;
        }

    }

    
}
