using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{
    public Rigidbody platform1,platform2;
    public GameObject prompt;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovementAdvanced>())
        {
           Invoke("DoStuff",2f);
        }
    }
    void DoStuff()
    {
        platform1.useGravity = true;
        platform2.isKinematic=false;
        platform2.useGravity = true;
        platform2.AddForce(10*Vector3.down,ForceMode.Impulse);

        DG.Tweening.DOTween.To(value => Time.timeScale = value, 1, 0.4f, 2f).SetEase(Ease.InCubic).onComplete =ShowPrompt;
    }
    void ShowPrompt()
    {
        prompt.SetActive(true);
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
