using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public GameObject beansCollectedCounter;

    public Text flapUpgradeValue;
    public Text speedUpgradeValue;
    public Text beanSpawnUpgradeValue;
    public TMP_Text beanCounter;

    [SerializeField] private int flapUpgradeCost;
    [SerializeField] private int speedUpgradeCost;
    [SerializeField] private int beanSpawnUpgradeCost;

    public Text flapUpgradeLevelText;
    public Text speedUpgradeLevelText;
    public Text beanSpawnUpgradeLevelText;

    private int flapLevel = 1;
    private int speedLevel = 1;
    private int beanSpawnLevel = 1;

    public AudioSource source;
    public AudioClip upgrade;
    public AudioClip nope;

    private static playerScript playerScript;
    private static Bean beanScript;
    private static Game gameScript;
    private static Caffine caffineScript;

    private int _beansCollected;

    public int beansCollected
    {
        get { return _beansCollected;}
        set
        {
            _beansCollected = value;
            beanCounter.text = beansCollected.ToString();
        }
    }
    private void Start()
    {
        flapUpgradeCost = 5;
        speedUpgradeCost = 5;
        beanSpawnUpgradeCost = 10;

        flapUpgradeValue.text = flapUpgradeCost.ToString();
        speedUpgradeValue.text = speedUpgradeCost.ToString();
        beanSpawnUpgradeValue.text = beanSpawnUpgradeCost.ToString();

        playerScript = FindObjectOfType<playerScript>();
        beanScript = FindObjectOfType<Bean>();
        gameScript = FindObjectOfType<Game>();
        caffineScript = FindObjectOfType<Caffine>();
    }

    private void Update()
    {
        beanCounter.text = beansCollected.ToString();
        flapUpgradeValue.text = flapUpgradeCost.ToString();
        speedUpgradeValue.text = speedUpgradeCost.ToString();
        beanSpawnUpgradeValue.text = beanSpawnUpgradeCost.ToString();
    }

    public void OnFlapUpgradePress()
    {
        if (beansCollected >= flapUpgradeCost)
        {
            source.PlayOneShot(upgrade);
            beansCollected -= flapUpgradeCost;
            flapUpgradeCost += 10;
            flapLevel++;
            flapUpgradeLevelText.text = "LVL: " + flapLevel;
            playerScript.velocity++;
            caffineScript.repeatRate -= 0.1F;
        }
        else
        {
            source.PlayOneShot(nope);
        }
    }

    public void OnSpeedUpgradePress()
    {
        if (beansCollected >= speedUpgradeCost)
        {
            source.PlayOneShot(upgrade);
            beansCollected -= speedUpgradeCost;
            speedUpgradeCost += 10;
            speedLevel++;
            speedUpgradeLevelText.text = "LVL: " + speedLevel;
            beanScript.speed *= 2;
            caffineScript.repeatRate -= 0.2F;
        }
        else
        {
            source.PlayOneShot(nope);
        }
    }
    
    public void OnBeanSpawnUpgradePress()
    {
        if (beansCollected >= beanSpawnUpgradeCost)
        {
            source.PlayOneShot(upgrade);
            beansCollected -= beanSpawnUpgradeCost;
            beanSpawnUpgradeCost += 15;
            beanSpawnLevel++;
            beanSpawnUpgradeLevelText.text = "LVL: " + beanSpawnLevel;
            gameScript.respawnTime -= 0.3f;
            caffineScript.repeatRate -= 0.3F;
        }
        else
        {
            source.PlayOneShot(nope);
        }
    }
}
