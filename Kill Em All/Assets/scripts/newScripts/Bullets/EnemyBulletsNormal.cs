using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletsNormal : Bullets
{
    //speed 48
    //life 15
    //distance = 20
    public void SetVariables(int speed, int GivenLayer, string targetTagName)
    {
        this.speed = speed;
        this.givenLayer = GivenLayer;
        this.targetTagName = targetTagName;
    }
}
