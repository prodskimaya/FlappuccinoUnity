using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public AudioSource source;
    public void ONStartClicked()
    {
        SceneManager.LoadScene("Game");
    }
}
