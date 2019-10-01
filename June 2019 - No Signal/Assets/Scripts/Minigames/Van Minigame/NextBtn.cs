using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextBtn : MonoBehaviour
{
    public void OnNextClick()
    {
        Time.timeScale = 1.0f;

        // Load next scene
        SceneManager.LoadScene(Rememberer.roomToRememeber);
    }
}
