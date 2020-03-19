using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMissile : Bullets
{
    //speed 30
    //rotate speed = 200f
    [SerializeField]
    float rotateSpeed;
    [SerializeField]
    Player playerTarget;
    Rigidbody2D rb;
    protected override void Start()
    {
        base.Start();
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerTarget = manager.managerInstance.playerInstance;
    }
    public void SetVariables(int speed, int rotateSpeed, string targetTagName)
    {
        this.speed = speed;
        this.rotateSpeed = rotateSpeed;
        this.targetTagName = targetTagName;
    }

    protected override void move()
    {
       // base.move();
        Vector2 direction = (Vector2)playerTarget.transform.position - rb.position;
        direction.Normalize();

        float rotate = Vector3.Cross(direction, transform.up).z;

        rb.angularVelocity = -rotate * rotateSpeed;

        rb.velocity = transform.up * speed;
        DestroyBullet(5f);
    }
}
