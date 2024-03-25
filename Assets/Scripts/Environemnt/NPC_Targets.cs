using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.VFX;

public class NPC_Targets : MonoBehaviour
{
    public Transform moveTarget1, moveTarget2, moveTarget3, moveTarget4,door2,door3;
    public Image panel;
    Transform self;
    public VisualEffect kapow;
    public GameObject textPrompt;
    public Image chargeBar;
    public Sprite fullCharge;
    public Sprite halfCharge;
    public bool isInRange = false;
    bool doOnce = true;
    public int buttonCount=0;
    public int thirdCheck =0;
    void OnEnable()
    {
        FirstDoor.moveFirst += MoveFirst;
        FriendButton.friendHere += HandleFriend;
        SecondDoor.playerHere += HandleFriend;
        ThirdDoor.playerHere += HandleThird;
        PlayerMovementAdvanced.teleported += UpdateSprite;
    }

    private void UpdateSprite()
    {
        chargeBar.sprite = fullCharge;
        panel.gameObject.SetActive(true);
    }

    void MoveThird()
    {
        this.gameObject.transform.DOMove(new Vector3(47.012f, 1.33f, 34.895f), 3f);
    }
    private void HandleFriend()
    {
        buttonCount++;
        Debug.Log("Button count at "+buttonCount.ToString());
        switch (buttonCount)
        {
            case 2:
                door2.DOMoveY(5f ,1f);
                SoundManager.Instance.PlaySFX("whoosh");
                Invoke("MoveThird",2f);
                break;
            case 4:

                break;
            default:
                // code block
                break;
        }
    }

    void OnDisable()
    {
        FirstDoor.moveFirst -= MoveFirst;
        FriendButton.friendHere -= HandleFriend;
        SecondDoor.playerHere -= HandleFriend;
        ThirdDoor.playerHere -= HandleThird;
        PlayerMovementAdvanced.teleported -= UpdateSprite;
    
    }

    private void HandleThird()
    {
        if(thirdCheck>=0)
        {
                door3.DOMove(new Vector3(51.5f,7f,30.52f) ,1f);
                SoundManager.Instance.PlaySFX("whoosh");
                Invoke("MoveFourth",2f);
        }
    }

    void MoveFirst()
    {
        this.gameObject.transform.DOMove(moveTarget1.position, 2f);
    }
    void MoveSecond()
    {
        this.gameObject.transform.DOMove(new Vector3(20, 0.125f, 21), 3f);
    }

        void MoveFourth()
    {
        this.gameObject.transform.DOMove(new Vector3(78.6f, 1.3f, 26.29f), 3f);
    }
    private IEnumerator DisableObjectAfterDelay()
    {
        yield return new WaitForSeconds(3f);
        textPrompt.SetActive(false);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {
            textPrompt.SetActive(true);
            isInRange = true;
            StartCoroutine(DisableObjectAfterDelay());

        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {
            isInRange = false;
            textPrompt.SetActive(false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        self = this.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            kapow.Play();
            textPrompt.SetActive(false);
            chargeBar.sprite = fullCharge;
            if (doOnce)
            {
                MoveSecond();
                doOnce = false;
            }
        }
    }
}
