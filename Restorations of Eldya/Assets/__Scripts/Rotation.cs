using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    // Update is called once per frame
    private void Update()
    {
        //rotates object based on the speed
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
    }
}
