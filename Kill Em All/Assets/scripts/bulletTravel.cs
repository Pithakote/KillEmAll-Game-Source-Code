using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletTravel : MonoBehaviour {


    public float speed;
    public float lifeTime;
    public float distance;
    public LayerMask solid;
    public GameObject destroyParticle;
    public float playerScore = 0f;
    int score = 0;
    public int bossDmg;
    private cameraShake shake;
    public int dmg ;
    private GameObject explosionClone;
    // Use this for initialization
    void Start () {
        bossDmg = 5;
        Destroy(gameObject, lifeTime);
      //  damageSound = GetComponent<AudioSource>();
        Invoke("bulletDestroy", lifeTime);
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();
	}

	
	// Update is called once per frame
	void Update () {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, solid);
 

        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                Debug.Log("Enemy dead");
                shake.CamShake2();
              //  damageSound.Play();
                hitInfo.collider.GetComponent<enemy>().takesDmg(dmg);
            }
            bulletDestroy();
            
        }

        transform.Translate(Vector2.up * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("boss"))
        {
            collision.GetComponent<bossAI>().bossDecreaseHealth(bossDmg);
            shake.CamShake2();
            bulletDestroy();
        }
    }
    void bulletDestroy()
    {

        explosionClone = (GameObject)Instantiate(destroyParticle, transform.position, Quaternion.identity);
        Destroy(explosionClone, 0.5f);
        Destroy(gameObject);
    }
}
