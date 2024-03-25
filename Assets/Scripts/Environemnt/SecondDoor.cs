using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SecondDoor : MonoBehaviour
{
    static public Action playerHere;
    public Light light2;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {
            //Debug.Log();
            playerHere?.Invoke();
            light2.color=Color.green;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {

        }
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
