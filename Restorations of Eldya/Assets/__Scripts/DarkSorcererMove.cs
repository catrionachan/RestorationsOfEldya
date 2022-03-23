using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSorcererMove : MonoBehaviour
{
    public float speed;
    private Transform target;
    public Animator anim;   
    private bool ev = false;

    void Start() {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
    } 
    public void Move() {
        if(target.position.x >= 63) {
            anim.SetBool("OnEnter", true);
            ev = true;
        }
        if(ev == true){
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    

}
}