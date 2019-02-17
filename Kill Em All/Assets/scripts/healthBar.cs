using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthBar : MonoBehaviour
{
    public Transform bar;
    private float ratio;
    // Use this for initialization
    private float maxHealth = 15;
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        int currentHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<playerMovement>().health;
        float hp = (float)currentHealth;
        ratio = currentHealth / maxHealth;
        bar.localScale = new Vector3(ratio, 1f);
    }
}
