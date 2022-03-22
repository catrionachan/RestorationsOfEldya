using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour
{

    static public MainController S; //Singleton of the class Main

    //Variables that can change the Inspector
    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies; //array to hold the prefab enemies that can spawn
    public float enemySpawnRate = 0.00001f; //spawn rate of enemies (enemy per second)
    public float enemyDefltPadd = 1.5f; //padding for enemy

    private BoundsCheck _bndCheck;
    void Awake()
    {
        S = this;
        // Set bndCheck to reference the BoundsCheck component on this GameObject
        _bndCheck = GetComponent<BoundsCheck>();
    }

    public void SpawnEnemy()
    {

        // Pick a random Enemy prefab to instantiate
        int index = Random.Range(0, prefabEnemies.Length); //gets a random integer between 0 and the length of the array -1
        GameObject enemy = Instantiate<GameObject>(prefabEnemies[index]); //creates a gameObject based on the object at the index

        // Position the gameObject for Enemy Enemy above the screen with a random x position
      
        // creates a Vector 3 positioning to set the Enemy initial position
        Vector3 positioning = Vector3.zero;
        //finds the minimum and maximum x position value to have the enemy within the screen
        //sets a random x position between the minimum and maximum x values
       
        positioning.y = 0f;
        positioning.x = 5;
        //set y position above the screen
        enemy.transform.position = positioning;
        // Invoke Spawn after 2 seconds
        Invoke("SpawnEnemy", 1f / enemySpawnRate);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
