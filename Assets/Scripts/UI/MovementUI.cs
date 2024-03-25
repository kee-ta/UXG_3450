using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using DG.Tweening;
using TMPro;

public class MovementUI : MonoBehaviour
{
    public AudioSource playSource;
    public GameObject playButton, quitButton, readyUpObject;
    public RectTransform mainMenuContainer;
    public static Action startGame;
    public TextMeshProUGUI readyText;
    Vector3 mainMenuPos, targetMenuPos;
    public Camera readyCam,mainCam;

    public GameObject player1, player2, mainMenuObject;

    public ParticleSystem slash;
    void SwitchMenus()
    {
        player1.SetActive(true);
        mainMenuObject.SetActive(false);
        readyUpObject.SetActive(true);
        mainCam.gameObject.SetActive(false);
        readyCam.gameObject.SetActive(true);
        Invoke("FakeJoin", 7.0f);
    }
    void SetReadyColor()
    {
        readyText.color = new Color32(255,253,213,255);
    }

    void FakeJoin()
    {
        player2.SetActive(true);
        readyText.color = new Color32(255,253,213,255);
        readyText.text = "Start";
    }
    // Start is called before the first frame update
    void Start()
    {
        mainMenuPos = mainMenuContainer.position;
        targetMenuPos= new Vector3(mainMenuPos.x,mainMenuPos.y,-800);
    }

    public void PlayGame()
    {
        mainMenuContainer.DOMove(targetMenuPos,0.7f).onComplete=SwitchMenus;
        var main = slash.main;
        main.simulationSpeed = 0.5f;
        playSource.Play();
        slash.Play();
        startGame?.Invoke();
    }
    public void ExitGame()
    {
       Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
