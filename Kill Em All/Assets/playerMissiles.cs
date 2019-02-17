using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMissiles : MonoBehaviour {

    Transform enemyTarget;
    Transform bossTarget;
    float speed = 84;
    float rotateSpeed = 200f;
    public GameObject destroyParticle;
    private Rigidbody2D rb;
    public float distance;
    GameObject boss;
    public LayerMask solid;
    private cameraShake shake;
    // Use this for initialization
    void Start () {
        if (GameObject.FindGameObjectWithTag("Enemy") != null)
        {
            enemyTarget = GameObject.FindGameObjectWithTag("Enemy").transform;
        }
        else
        {

            enemyTarget = GameObject.FindGameObjectWithTag("wall").transform;
        }
            rb = GetComponent<Rigidbody2D>();
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();
        Destroy(gameObject,7);
        //boss = GameObject.FindGameObjectWithTag("bossHandle").gameObject;
        //  enemyTarget = GameObject.FindGameObjectWithTag("boss").transform;
    }
    void FixedUpdate()
    {
        
            Vector2 direction = (Vector2)enemyTarget.position - rb.position;
            direction.Normalize();

            float rotate = Vector3.Cross(direction, transform.up).z;

            rb.angularVelocity = -rotate * rotateSpeed;

            rb.velocity = transform.up * speed;
            
        
        /*else
        {
            RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);


            if (hitInfo.collider != null)
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy dead");
                    shake.CamShake2();
                    //  damageSound.Play();
                    hitInfo.collider.GetComponent<enemy>().takesDmg(4);
                }
                bulletDestroy();

            }

            transform.Translate(Vector2.up * speed * Time.deltaTime);
            if (GameObject.FindGameObjectWithTag("Enemy") != null)
            {
                Vector2 direction = (Vector2)enemyTarget.position - rb.position;
                direction.Normalize();

                float rotate = Vector3.Cross(direction, transform.up).z;

                rb.angularVelocity = -rotate * rotateSpeed;

                rb.velocity = transform.up * speed;
            }
        }
            /*if (boss.activeSelf)
        {
            Vector2 direction2 = (Vector2)bossTarget.position - rb.position;
            direction2.Normalize();

            float rotate2 = Vector3.Cross(direction2, transform.up).z;

            rb.angularVelocity = -rotate2 * rotateSpeed;

            rb.velocity = transform.up * speed;
        }*/
        }
    void bulletDestroy()
    {

        Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            // Destroy(target);
            enemyTarget.GetComponent<enemy>().takesDmg(5);
            Instantiate(destroyParticle, transform.position, transform.rotation);
        }
        if (collision.CompareTag("wall"))
        {
            Destroy(gameObject);
            // Destroy(target);
            //enemyTarget.GetComponent<enemy>().takesDmg(5);
            Instantiate(destroyParticle, transform.position, transform.rotation);
        }

    }
    // Update is called once per frame
    void Update () {
		
	}
}
