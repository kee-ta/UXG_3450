using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;
using DG.Tweening;

public class DoorController : MonoBehaviour
{
    public Light light1,light2;
    public Transform door;

    void OnEnable()
    {
        ButtonController.activate+=ActivateLight;
    }

    void OnDisable()
    {
        ButtonController.activate-=ActivateLight;
    }
    void ActivateLight()
    {
        Debug.Log("Activated!");
        light2.color=Color.green;
        door.DOMoveY(3f ,1f);
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
