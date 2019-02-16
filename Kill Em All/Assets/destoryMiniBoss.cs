using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoryMiniBoss : MonoBehaviour {
    public GameObject destroyParticle;
    private cameraShake shake;
    private int health = 5;
    // Use this for initialization
    void Start () {
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();

    }

    // Update is called once per frame
    void Update () {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
	}

    public void destroyItself()
    {
        shake.CamShake2();
       // health -= 1;
       // Instantiate(destroyParticle, transform.position, transform.rotation);
    }
}
