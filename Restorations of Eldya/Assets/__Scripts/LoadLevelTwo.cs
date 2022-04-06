using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevelTwo : MonoBehaviour
{
    

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();//sets collider with PlayerMovements
            PlayerMovementZoro player2 = collider.GetComponent<PlayerMovementZoro>();
            PlayerMovementAstro player3 = collider.GetComponent<PlayerMovementAstro>();

            if (player != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            if (player2 != null)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
            if (player3 != null)
            {
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            }
        }

        
    }
}
