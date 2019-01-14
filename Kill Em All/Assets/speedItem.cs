using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedItem : MonoBehaviour
{

    //   public float speed;
    public float lifeTime;
    //  private Transform player;
    //   private Vector2 target;
    //   public float distance;
    //   public LayerMask solid;
    // Use this for initialization
    void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("player detected");
            addSpeed();
            DestroyProjectile();
        }
    }

    void addSpeed()
    {
        GameObject.Find("player").GetComponent<playerMovement>().speed += 10;
    }
    void DestroyProjectile()
    {
        //  GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health -= 1;
        Destroy(gameObject);
    }

    IEnumerator normalSpeed()
    {
        yield return new WaitForSeconds(6f);
        GameObject.Find("player").GetComponent<playerMovement>().speed += 12;
    }
}
