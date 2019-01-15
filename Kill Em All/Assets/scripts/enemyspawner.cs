using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class enemyspawner : MonoBehaviour {

    public AudioSource source;
    public AudioClip[] musicArray;
    private AudioClip clip;

    public TMP_Text wave;
    public GameObject hazard;
   // public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int healthincrease;
    public GameObject bullet;
    public int waveNumber = 1;
    
    void Start ()
    {
       
        StartCoroutine (SpawnWaves ());
    }
    private void Update()
    {
        wave.text = "Wave: " + waveNumber;
      

    }
    public void OnDisable()
    {
        PlayerPrefs.SetInt("Score", waveNumber);
    }
        IEnumerator SpawnWaves ()
    {
        yield return new WaitForSeconds (startWait);
       
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3 (Random.Range (transform.position.x, transform.position.x + 50), Random.Range(transform.position.y, transform.position.y-50), transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate (hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds (spawnWait);
            }
            yield return new WaitForSeconds (waveWait);
            int index = Random.Range(0, musicArray.Length);
            clip = musicArray[index];
            source.clip = clip;
            source.Play();
           bullet.GetComponent<bulletTravel>().dmg += 1;
            waveNumber += 1;
            bullet.GetComponent<bulletTravel>().speed += 0.2f;
            healthincrease += 1;
            waveWait += 1;
           // GameObject.Find("player").GetComponent<playerMovement>().health += healthincrease;
            hazardCount += 1;
            spawnWait -= 0.5f;
        }
    }
}
