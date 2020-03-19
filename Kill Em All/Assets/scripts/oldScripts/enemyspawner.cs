﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class enemyspawner : MonoBehaviour {

    public AudioSource source;
    public AudioClip[] musicArray;
    private AudioClip clip;
    private cameraShake shake;
    public TMP_Text wave;
    public GameObject hazard;
    // public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int healthincrease;
    public GameObject bullet;
    public bool contSmallEnemies;
    public int waveNumber = 1;
    public int nowaveNumber = 7;
    public int maxWave = 3;
    public GameObject boss;
    Vector2 screenBoundray;
    GameObject healthSpawner;
    IEnumerator spawnStop;
    void Start()
    {
        screenBoundray = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        healthSpawner = GameObject.FindGameObjectWithTag("healthSpawner").gameObject;

        boss.SetActive(false);
         spawnStop = SpawnWaves();
        StartCoroutine(spawnStop);
        shake = GameObject.FindGameObjectWithTag("screenShake").GetComponent<cameraShake>();

    }
    private void Update()
    {

        wave.text = "Wave: " + waveNumber;

       

    }
    public void OnDisable()
    {
        PlayerPrefs.SetInt("Score", waveNumber);
    }
    private void FixedUpdate()
    {
        
    }
   
    IEnumerator SpawnWaves()
    {

        yield return new WaitForSeconds(startWait);

        while (true)
        {
          
                for (int i = 0; i < hazardCount; i++)
                {
                if (waveNumber == nowaveNumber)
                {
                    shake.IntroBoss();
                    boss.SetActive(true);
                    StopCoroutine(spawnStop);
                    //   SceneManager.LoadScene("final");
                }
               
                Vector2 spawnPosition = new Vector2(Random.Range(0, screenBoundray.x), Random.Range(screenBoundray.y, 0));//, transform.position.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(spawnWait);
                }
                yield return new WaitForSeconds(waveWait);
                int index = Random.Range(0, musicArray.Length);
                clip = musicArray[index];
                source.clip = clip;
                source.Play();
                hazard.GetComponent<enemy>().health += 2;
                //bullet.GetComponent<bulletTravel>().dmg += 1;
                waveNumber += 1;

                //bullet.GetComponent<bulletTravel>().speed += 0.2f;
                //healthincrease += 1;
                waveWait += 10;
                // GameObject.Find("player").GetComponent<playerMovement>().health += healthincrease;
                hazardCount += 3;
                spawnWait -= 0.5f;
            if (waveNumber == 4)
            {
                healthSpawner.GetComponent<healthBoost>().spawnCount = 4;
                healthSpawner.GetComponent<healthBoost>().spawnWait = 2;
                healthSpawner.GetComponent<healthBoost>().waveWait = 2;
                
               
            }
            if (waveNumber == 5)
            {
                healthSpawner.GetComponent<healthBoost>().spawnCount = 3;
                healthSpawner.GetComponent<healthBoost>().spawnWait = 2;
                healthSpawner.GetComponent<healthBoost>().waveWait = 2;
            }
            if (waveNumber == 6)
            {
                healthSpawner.GetComponent<healthBoost>().spawnCount = 3;

                healthSpawner.GetComponent<healthBoost>().spawnWait = 4;
                healthSpawner.GetComponent<healthBoost>().waveWait = 5;
            }
            else
            {

            }




        }

    } 
        
        
    
}
