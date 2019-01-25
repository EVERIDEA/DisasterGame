using System;
using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Menu : GameStateMachine<Menu>
{

    public enum States{
        None,
        LevelSelect,
        Options,
        Credit,
        Share
    }
    

    private GameObject[] Buttons;

    private void Awake()
    {
        Initialize<States>();
        Buttons = GameObject.FindGameObjectsWithTag("UIButton");
    }

    private void Start()
    {
        SignalManager.Instance.AttachReceiver("button.menuui", this.OnSignalReceived);
    }

    private void OnSignalReceived(Dictionary<string, object> eventParam)
    {
		var action = (String)eventParam["action"];
		var value = action.Split(new[] { "#" }, StringSplitOptions.RemoveEmptyEntries);

        switch (value[0]) {
            case "menu.play":
                ChangeState(States.LevelSelect);
                break;
            case "menu.option":
                ChangeState(States.Options);
                break;
            case "menu.credit":
                ChangeState(States.Credit);
                break;
            case "menu.share":
                Debug.Log("METHOD DOESN'T EXIST");
                break;
            case "menu.quit":
                Application.Quit();
                Debug.Log("QUIT");
                break;
			case "level.select":
                if (value[1] == "1")
                {
                    Debug.Log("LEPEL 1");
                    Global.LevelSelect = 1;
                }
                if (value[1]== "2")
                {
                    Debug.Log("LEPEL 2");
                    Global.LevelSelect = 2;
                }
                Application.LoadLevel("Game");
                Debug.Log("Open Level");
                break;
            default:
                ChangeToPreviousState();
                break;
        }
    }

    public void ToggleButtons(bool Show)
    {
        Buttons.ToList().ForEach(g => g.gameObject.SetActive(Show));
    }
}
