using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{

private Rigidbody2D rb;
public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
    
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.localPosition = new Vector2(rb.position.x-speed,rb.position.y);

        if(rb.position.x <= -20){
            Destroy(gameObject);

        }
    }
}
