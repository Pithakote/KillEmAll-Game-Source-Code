using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class missileShoot : MonoBehaviour
{    public GameObject missileSpawner1;
    public GameObject missiles;
    public int missilesCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    // Use this for initialization
    void Start()
    {
        if(gameObject.activeSelf)
        StartCoroutine(SpawnWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);

        while (true)
        {
            for (int i = 0; i < missilesCount; i++)
            {
                // Vector2 spawnPosition = new Vector2(Random.Range(transform.position.x, transform.position.x + 150), Random.Range(transform.position.y, transform.position.y - 100));//, transform.position.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(missiles, missileSpawner1.transform.position, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
                
            }
            //StopCoroutine(SpawnWaves());
           // yield return new WaitForSeconds(waveWait);
        }

    }
}
