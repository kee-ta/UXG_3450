using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class ButtonController : MonoBehaviour
{
    public Transform button;
    Vector3 resetPos;
    public PlayerMovementAdvanced player;
    bool onButton = false;
    private float playHeight;
    bool doOnce = true;

    public static Action activate;
    // Start is called before the first frame update
    void Start()
    {
        resetPos = button.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
    void FixedUpdate()
    {
        /*
        if(onButton)
        {
            button.DOMoveY(-1.07f,0.5f);
        }
        else
        {
             //button.DOMoveY(-0.935f,0.5f);
        }
        */
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {
            onButton = true;
            button.DOMoveY(-1.063f, 0.5f);
            if(doOnce)
            {
            activate?.Invoke();
            doOnce=false;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {
            onButton = false;
            button.DOMoveY(resetPos.y, 0.5f);
            doOnce=true;
        }
    }
}
