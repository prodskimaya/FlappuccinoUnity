using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caffine : MonoBehaviour
{
    public int currentCaffine;
    public int maxCaffine = 100;
    public float repeatRate = 1.0F;

    public CaffineBar caffineBar;

    private void Start()
    {
        currentCaffine = maxCaffine;
        InvokeRepeating("LoseCaffine", 1, repeatRate);
    }

    void LoseCaffine()
    {
        currentCaffine -= 10;
        caffineBar.SetCaffine(currentCaffine);
    }

    public void ResetCaffine()
    {
        caffineBar.SetCaffine(100);
    }
}
