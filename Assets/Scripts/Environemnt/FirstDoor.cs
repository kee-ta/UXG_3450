using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using System;

public class FirstDoor : MonoBehaviour
{
    public static Action moveFirst;
    public GameObject door1,door11;
    public Light light1;

    void DelayedDoorOpen()
    {
        door11.transform.DOMoveY(5,1);
        moveFirst?.Invoke();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {
            door1.transform.DOMoveY(5,1);
            SoundManager.Instance.PlaySFX("whoosh");
            light1.color=Color.green;
            Invoke("DelayedDoorOpen",2f);
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
