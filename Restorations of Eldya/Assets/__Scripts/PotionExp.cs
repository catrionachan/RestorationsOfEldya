using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionExp : MonoBehaviour
{
    private Transform player;
    public float expPoints;
    private Vector3 target;
    [SerializeField]
    private FloatSO scoreSO;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        target = new Vector2(player.position.x, player.position.y);



    }

    // Update is called once per frame
    void Update()
    {
        

    }

    //OnTrigger event which sees if the potion collides with player
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            PlayerMovement player = collider.GetComponent<PlayerMovement>();//sets collider with PlayerMovements
            PlayerMovementZoro player2 = collider.GetComponent<PlayerMovementZoro>();
            PlayerMovementAstro player3 = collider.GetComponent<PlayerMovementAstro>();

            if (player != null)
            {
                player.gainExperience(expPoints);//player health is updated on collision
                Destroy(gameObject);
                scoreSO.Value += expPoints;
            }
            if (player2 != null)
            {
                player2.gainExperience(expPoints);//player health is updated on collision
                Destroy(gameObject);
                scoreSO.Value += expPoints;
            }
            if (player3 != null)
            {
                player3.gainExperience(expPoints);//player health is updated on collision
                Destroy(gameObject);
                scoreSO.Value += expPoints;
            }
        }

    }
}
