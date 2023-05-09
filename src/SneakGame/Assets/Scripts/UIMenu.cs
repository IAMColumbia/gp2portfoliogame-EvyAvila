using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class UIMenu : MonoBehaviour
{
    public GameObject Game;
    private DefaultPlayerControl defaultPlayerControl;
    private InputAction MouseClick;

    private void Awake()
    {
        defaultPlayerControl = new DefaultPlayerControl();
    }

    private void OnEnable()
    {
        MouseClick = defaultPlayerControl.Player.Pointer;
        MouseClick.Enable();
    }

    private void OnDisable()
    {
        MouseClick.Disable();
    }


    private void Update()
    {
        SwitchUIGame();
    }

    void SwitchUIGame()
    {
        var value = MouseClick.ReadValue<float>();

        if(value > 0)
        {
            Game.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

    

    

}
