using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour
{
    public float velocity;
    private Rigidbody2D rb;
    private BoxCollider2D deathBarriers;

    public AudioSource source;
    public AudioClip flap;
    public AudioClip bean;
    public AudioClip dead;

    public GameObject cam;
    public GameObject beanObj;
    public GameObject deathScreen;
    public GameObject player;

    private static Shop shop;
    private static Caffine caffineScript;

    private bool hasDeathSFXplayed = false;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        shop = FindObjectOfType<Shop>();
        caffineScript = FindObjectOfType<Caffine>();
        deathScreen.SetActive(false);
        deathBarriers = GameObject.FindGameObjectWithTag("barriers").GetComponent<BoxCollider2D>();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) && caffineScript.currentCaffine > 0)
        {
            rb.velocity = Vector2.up * velocity;
            source.PlayOneShot(flap);
        }

        if (caffineScript.currentCaffine <= 0)
        {
            if (hasDeathSFXplayed == false)
            {
                source.PlayOneShot(dead);
                deathScreen.SetActive(true);
                hasDeathSFXplayed = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "barriers")
        {
            caffineScript.currentCaffine = 0;
        }
        else
        {
            source.PlayOneShot(bean);
            caffineScript.currentCaffine = 100;
            caffineScript.ResetCaffine();
            shop.beansCollected++;
        }
    }
}
