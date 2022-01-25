using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaffineBar : MonoBehaviour
{
    public Slider caffineBar;
    public Caffine playerCaffine;

    void Start()
    {
        playerCaffine = GameObject.FindGameObjectWithTag("Player").GetComponent<Caffine>();
        caffineBar = GetComponent<Slider>();
        caffineBar.maxValue = playerCaffine.maxCaffine;
        caffineBar.value = playerCaffine.currentCaffine;
    }

    public void SetCaffine(int caffine)
    {
        caffineBar.value = caffine;
    }
}
