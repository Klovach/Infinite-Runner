using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed;
    void Start()
    {
        speed = 1f; 
        InvokeRepeating("IncreaseSpeed", 5f, 5f); 
    }
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0); 
    }
    void IncreaseSpeed()
    {
        speed += 0.1f; 
    }
}
