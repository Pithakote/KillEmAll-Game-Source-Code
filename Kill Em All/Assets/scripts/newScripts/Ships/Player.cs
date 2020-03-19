using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
[System.Serializable]
public class Player : Ships
{
    [SerializeField]
    int turningSpeed;
   
    public void setVariables(int playerHealth, int speed, int turningspeed, float delayShot, float startDelayShot)
    {
        Debug.Log("Constructor");
        this.health = playerHealth;
        this.speed = speed;
        this.turningSpeed = turningspeed;
        this.delayShot = delayShot;
        this.startDelayShot = startDelayShot;
    }
    
    protected override void move()
    {
        Vector2 moveVector = new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"), CrossPlatformInputManager.GetAxis("Vertical"));
        Vector2 moveVelocity2 = moveVector.normalized * speed;

        // rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + moveVelocity2 * Time.fixedDeltaTime);
        Vector3 lookVector = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal2"), CrossPlatformInputManager.GetAxis("Vertical2"), turningSpeed);
        if (lookVector.x != 0 && lookVector.y != 0)
            transform.rotation = Quaternion.LookRotation(lookVector, Vector3.back);

    }

    protected override void shoot()
    {
       // Debug.Log("ShooterInherits");
        if (delayShot <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                foreach (Transform spawnPoint in bulletSpawners)
                    Instantiate(bullets, spawnPoint.position, spawnPoint.transform.rotation);

                delayShot = startDelayShot;
            }
        }
        else
        {
            delayShot -= Time.deltaTime;
        }
    }
}
