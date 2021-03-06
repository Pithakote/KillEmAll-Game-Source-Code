﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class bossAI : MonoBehaviour {
    private float timeBetShots;
    public float startTimeBetShots;
    public Transform spawner1;
    public Transform spawner2;
    public GameObject enemyBullet;
    public int healthBoss ;
    private cameraShake shake;
    public bool bossDefeat = false;
    public GameObject homingSpawner;
    public Animator bossAnim;
    public GameObject homingMissiles;
    // public Vector3 spawnValues;
    public TMP_Text wave;
    GameObject smallEnemySpawn;
    public int waveNumber = 1;
    public Transform player;
    public bool move = false;
    public GameObject miniBoss;
    public GameObject sceneManager;
    // public int maxHealth = 2000;
    // Use this for initialization
    void Start () {
        healthBoss = 2000;
        sceneManager = GameObject.FindGameObjectWithTag("transitionScene").gameObject;

        //wave.text = "BOSS ";
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();
        gameObject.GetComponent<hmissileScript>().enabled = false;
        miniBoss.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBetShots = startTimeBetShots;
       // StartCoroutine(SpawnWaves());

    }
   /* IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < missilesCount; i++)
            {
                // Vector2 spawnPosition = new Vector2(Random.Range(transform.position.x, transform.position.x + 150), Random.Range(transform.position.y, transform.position.y - 100));//, transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(homingMissiles, homingSpawner.transform.position, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
        
    }*/
    private void FixedUpdate()
    {
        if (healthBoss <= 1000)
        {

            enemyBullet.GetComponent<enemyBullet>().speed = 42;
            //enemyBullet.GetComponent<enemyBullet>().distance = 30;
            miniBoss.SetActive(true);
            gameObject.GetComponent<hmissileScript>().enabled = true;
            move = true;
            // miniBoss.SetActive(true);
            startTimeBetShots = 0.3f;
            Debug.Log("Health boss 50");
            
        }
        if (healthBoss <= 1500)
        {
            enemyBullet.GetComponent<enemyBullet>().speed = 35;
            enemyBullet.GetComponent<enemyBullet>().distance = 30;
            startTimeBetShots = 0.5f;
            bossAnim.SetTrigger("moveTrigger");

        }
    }

    // Update is called once per frame
    void Update () {
        if (timeBetShots <= 0)
        {
            Instantiate(enemyBullet, spawner1.position, Quaternion.identity);
            Instantiate(enemyBullet, spawner2.position, Quaternion.identity);
            timeBetShots = startTimeBetShots;
        }
        else
        {
            timeBetShots -= Time.deltaTime;
        }
        
        if (healthBoss <= 0)
        {
            StartCoroutine(changeScene());

            
           // Destroy(gameObject);

        }
        if (bossDefeat == true)
        {
            gameObject.SetActive(false);
        }
    }
    IEnumerator changeScene()
    {
        sceneManager.GetComponent<sceneTransition>().changeScene();
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("yes");
        bossDefeat = true;
    }
    public void bossDecreaseHealth(int damage)
    {
        healthBoss -= damage;
    }
}
