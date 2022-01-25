using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class Game : MonoBehaviour
{
    public AudioSource source;
    public AudioClip upgrade;

    public GameObject beanPrefab;
    private Vector2 _screenBounds;
    public float respawnTime = 1.5f;
    public int beansCollected = 0;

    void Start()
    {
        source.PlayOneShot(upgrade); // Simulate Start Click Sound

        // beanManagement
        _screenBounds =
            Camera.main.ScreenToWorldPoint(new Vector3(-10.04f, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(BeanWave());
    }

    #region beanManagement

    private void SpawnBean()
    {
        GameObject a = Instantiate(beanPrefab) as GameObject;
        a.transform.position = new Vector2(_screenBounds.x * -2, Random.Range(-_screenBounds.y, _screenBounds.y));
    }

    IEnumerator BeanWave()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnBean();
        }
    }

    #endregion

    #region deathScreen

    public void returnToMenu()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void resetScene()
    {
        SceneManager.LoadScene("Game");
    }

    #endregion
}
