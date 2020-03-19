using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingMiniMissiles : Bullets
{

    public void SetVariables(int speed, string targetTagName)
    {
        this.speed = speed;
       
        this.targetTagName = targetTagName;
    }
}
