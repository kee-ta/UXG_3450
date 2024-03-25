using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSway : WeaponSway
{
    public Rigidbody player;
    public override Vector2 GetPlayerLookMovement()
    {
        return new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y"));
    }

    public override Vector3 GetPlayerVelocity()
    {
        return player.velocity;
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
