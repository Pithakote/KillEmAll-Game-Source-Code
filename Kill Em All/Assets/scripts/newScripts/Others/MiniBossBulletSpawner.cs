using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossBulletSpawner : enemies
{

    [SerializeField]
    bool isInitialPos, isReached;
    [SerializeField]
    Transform firstPos;
    public void setVariables(int health, int delaytime, int startdelaytime)
    {
        this.health = health;
        this.delayShot = delaytime;
        this.startDelayShot = startdelaytime;
    }
    protected override void Start()
    {
        base.Start();
        this.isInitialPos = false;
    }
    protected override void move()
    {

        
        if (isInitialPos ==false)
        {
            transform.position = Vector2.MoveTowards(gameObject.transform.position, firstPos.position, 10f * Time.deltaTime);
           
        }
        else
            transform.position = Vector2.Lerp(new Vector2(leftScreen.x, transform.position.y), new Vector2(screenBounds.x, transform.position.y), Mathf.PingPong(Time.time * 0.25f, 1f));//ping pong, second parameter determines how long the ship stays at the end, first parameter determines how long should it take to go to and from the two positions, larger number is faster and lowernumber is slower

        if (transform.position == firstPos.position)
        {
            Debug.Log("Initial pos reached");
            isInitialPos = true;
        }
        
            
       


    }
}
