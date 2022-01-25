using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deathBarriers : MonoBehaviour
{
    public Caffine caffineScript;

    private void Start()
    {
        caffineScript = FindObjectOfType<Caffine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            caffineScript.currentCaffine = 0;
        }
    }
}
