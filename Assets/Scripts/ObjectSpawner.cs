using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    public float maxCoolDown = 1000;
    private float coolDown;
    public GameObject car;
    public GameObject pigeon;
    // Start is called before the first frame update
    void Start()
    {
        coolDown = maxCoolDown;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        coolDown--;
        if(coolDown <= 0){
            int objectID = Random.Range(1, 3);
            print(objectID);
            switch (objectID)
            {
                case 1:
                    Instantiate(car);
                    break;
                case 2:
                    Instantiate(pigeon);
                    break;
            }
            coolDown = maxCoolDown;
        }
    }
}
