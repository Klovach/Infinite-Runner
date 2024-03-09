using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private int ObjectID = 1;
    public float maxCoolDown = 1000;
    private float coolDown;
    public GameObject car;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = maxCoolDown;
    }

    // Update is called once per frame
    void Update()
    {
        coolDown--;
        if(coolDown <= 0){
            Instantiate(car);
            coolDown = maxCoolDown;
        }
    }
}
