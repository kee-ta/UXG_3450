using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject player1, player2, mainMenuObject;

    void OnEnable()
    {
        MovementUI.startGame+=SwitchMenus;
    }
    void OnDisable()
    {
        MovementUI.startGame-=SwitchMenus;
    }

    void SwitchMenus()
    {
        player1.SetActive(true);
        mainMenuObject.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadDemo()
    {
        SceneManager.LoadScene("Demo_Build");
    }
}
