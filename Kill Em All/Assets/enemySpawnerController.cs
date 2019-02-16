using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawnerController : MonoBehaviour {

    GameObject spawner;
	// Use this for initialization
	void Start () {
        spawner = gameObject.GetComponent<enemyspawner>().gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        spawner.GetComponent<enemyspawner>().contSmallEnemies = true;
	}
}
