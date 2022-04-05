using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoroPlayer : MonoBehaviour
{
    public void PlayGame()
    {
        //Builds and loads game on the start to the home page
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
}
