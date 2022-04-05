using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelTwo : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void onTriggerEnter2D(Collider2D collision) 
    {
        if (GetComponent<Collider>().CompareTag("Player"))
        {
            PlayerMovement player = GetComponent<Collider>().GetComponent<PlayerMovement>();

            if (player != null) //if the play is not null, player takes the damage
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                //loads the next scene 
            }
        }

    }
}
