using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float speed;

    public Renderer bgRenderer;

    void Start()
    {
      //  speed = 1f;
       
       // InvokeRepeating("IncreaseSpeed", 5f, 5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
    void IncreaseSpeed()
    {
        speed += 0.1f;
    }
}
