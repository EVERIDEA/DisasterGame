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
                    Debug.Log("LEVEL 1");
                    Global.LevelSelect = 1;
                }

                if (value[1]== "2")
                {
                    Debug.Log("LEVEL 2");
                    Global.LevelSelect = 2;
                }

				if (value[1] == "3")
				{
					Debug.Log("LEVEL 3");
					Global.LevelSelect = 3;
				}

				if (value[1]== "4")
				{
					Debug.Log("LEVEL 4");
					Global.LevelSelect = 4;
				}

				if (value[1] == "5")
				{
					Debug.Log("LEVEL 5");
					Global.LevelSelect = 5;
				}

				if (value[1]== "6")
				{
					Debug.Log("LEVEL 6");
					Global.LevelSelect = 6;
				}

				if (value[1] == "7")
				{
					Debug.Log("LEVEL 7");
					Global.LevelSelect = 7;
				}

				if (value[1]== "8")
				{
					Debug.Log("LEVEL 8");
					Global.LevelSelect = 8;
				}

				if (value[1] == "9")
				{
					Debug.Log("LEVEL 9");
					Global.LevelSelect = 9;
				}

				if (value[1]== "10")
				{
					Debug.Log("LEVEL 10");
					Global.LevelSelect = 10;
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
