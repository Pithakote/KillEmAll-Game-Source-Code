using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))] //this code ensures that all classes that are ships should have rigidbody2d
public class Ships : MonoBehaviour, ITakeDamage //ITakeDamage is an interface because all ships take damage
{
    //variables that will be shared with all the child classes
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
    protected GameObject deathParticle;
    [SerializeField]
    AudioSource damageSoundSource;
    protected Vector2 leftScreen;
    protected Vector2 screenBounds;
    protected float objectWidth, objectHeight;

    //public getters because they will have to be changed when they take damage------------------------------------------------
    public int Health
    {
        get { return health; }
    }
    public bool IsDead
    {
        get { return isDead; }
    }
    //--------------------------------------------------------------------------
    protected virtual void Start()
    {
       // Gets the screen size according to the camera-------------------------------------------------------------------------------
        leftScreen = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));


        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
        //----------------------------------------------------------------------------------------------------------------------------
        if (gameObject.GetComponent<AudioSource>())
            damageSoundSource = GetComponent<AudioSource>();
        else
        {
            gameObject.AddComponent<AudioSource>();
            damageSoundSource = GetComponent<AudioSource>();
        }
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
        //left empty becayse the function will be inherited and overriden by the child classes
    }
    protected virtual void LateUpdate() //used late update to bound the ships to the screen size
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x * -1 + objectWidth, screenBounds.x-objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y- objectHeight);
        transform.position = viewPos;
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
