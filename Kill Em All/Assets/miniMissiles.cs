using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniMissiles : MonoBehaviour {
    float speed = 30f;
    float rotateSpeed = 200f;
    public GameObject destroyParticle;
    private Rigidbody2D rb;
    private cameraShake shake;
    int playerDmg;
    //  public Transform target;
    // Use this for initialization
    void Start () {
        playerDmg = 1;
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();

        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(destroyAfter());
    }
    void FixedUpdate()
    {


        

       
    }
    IEnumerator destroyAfter()
    {

        yield return new WaitForSeconds(3.5f);
        Destroy(gameObject);

    }
    // Update is called once per frame
    void Update () {
       // Vector2 direction = (Vector2)target.position - rb.position;
       // direction.Normalize();

        //float rotate = Vector3.Cross(direction, transform.up).z;

        //rb.angularVelocity = -rotate * rotateSpeed;
        rb.velocity = transform.up * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shake.CamShake2();
            if (collision.GetComponent<CircleCollider2D>().radius == 1.37f)
            {
                playerDmg = 0;
            }
            else
            {
                playerDmg = 1;
            }
            collision.GetComponent<playerMovement>().takeDmg(playerDmg);
        }
    }
}
