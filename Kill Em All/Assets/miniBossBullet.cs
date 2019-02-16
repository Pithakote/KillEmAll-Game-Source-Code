using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniBossBullet : MonoBehaviour {
    public GameObject miniMissiles;
    public Transform miniMissilesSpawner;
    public Transform miniMissilesSpawner2;
    // public Vector3 spawnValues;
    public int missilesCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    private int healthincrease;
    GameObject boss;
    public int waveNumber = 1;
    // Use this for initialization
    void Start () {
        boss = GameObject.FindGameObjectWithTag("boss").gameObject;
        StartCoroutine(SpawnWaves());
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (boss.GetComponent<bossAI>().bossDefeat == false)
        {
            for (int i = 0; i < missilesCount; i++)
            {
                // Vector2 spawnPosition = new Vector2(Random.Range(transform.position.x, transform.position.x + 150), Random.Range(transform.position.y, transform.position.y - 100));//, transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(miniMissiles, miniMissilesSpawner.position, spawnRotation);
                Instantiate(miniMissiles, miniMissilesSpawner2.position, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
        }
       
    }

    // Update is called once per frame
    void Update () {
        if (!boss.activeSelf)
        {

            Destroy(gameObject);
        }
    }
}
