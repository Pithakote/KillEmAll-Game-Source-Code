using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class Ships : MonoBehaviour, ITakeDamage
{
   [SerializeField]
    protected int health;
    [SerializeField]
    protected bool isDead;
    [SerializeField]
    protected List<Transform> bulletSpawners;
    [SerializeField]
    protected GameObject bullets;
    [SerializeField]
    protected int speed;
    protected Rigidbody2D rb;
    [SerializeField]
    protected float delayShot, startDelayShot;
    [SerializeField]
    public GameObject deathParticle;
    [SerializeField]
    AudioSource damageSoundSource;


    public int Health
    {
        get { return health; }
    }
    public bool IsDead
    {
        get { return isDead; }
    }
    protected virtual void Start()
    {
        damageSoundSource = GetComponent<AudioSource>();
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
    }
    protected void Update()
    {
        shoot();
    }

    protected virtual void FixedUpdate()
    {
        move();
    }
    protected virtual void move()
    {

    }

   protected virtual void shoot()
    {
        if (delayShot <= 0)
        {
            foreach(Transform spawnPoint in bulletSpawners)
            Instantiate(bullets, spawnPoint.position, Quaternion.identity);

            delayShot = startDelayShot;
        }
        else
        {
            delayShot -= Time.deltaTime;
        }
    }
    
   public virtual void takeDamage(int damageAmount)
    {
        health -= damageAmount;
        damageSoundSource.Play();
        die();
    }
    void die()
    {
        if (health <= 0)
        {
            isDead = true;
            Destroy(gameObject);
          
        }
    }


}
