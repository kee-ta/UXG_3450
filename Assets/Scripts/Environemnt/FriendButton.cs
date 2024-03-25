using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FriendButton : MonoBehaviour
{
    static public Action friendHere;
    public Light light1;
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<NPC_Targets>())
        {
            friendHere?.Invoke();
            light1.color=Color.green;
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
