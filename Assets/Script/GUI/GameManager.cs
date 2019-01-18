using System;
using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Pause))]
[AddComponentMenu("Component/Script/GameManager")]
public class GameManager : GameStateMachine<GameManager>
{

    public enum States
    {
        Intro, Pause, Playing, Result, Restart
    }

    private static GameManager _instance;

    public static GameManager Instance {
        get {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<GameManager>();

            if(_instance == null)
            {
                GameObject singleton = new GameObject("GameManager");
                _instance = singleton.AddComponent<GameManager>();
            }

            DontDestroyOnLoad(_instance);
            return _instance;
        }
    }

    private void Awake()
    {
        Initialize<States>();
    }
    private void Start()
    {
        SignalManager.Instance.AttachReceiver("button.gameui", this.OnSignalReceived);
        Play();
    }

    private void OnSignalReceived(Dictionary<string, object> eventParam)
    {
        var action = (String)eventParam["action"];

        switch (action)
        {
            case "game.cancel":
                ChangeState(States.Playing);
                break;
            case "game.home":
                Application.LoadLevel("Menu");
                break;
			case "game.pause":
				ChangeState (States.Pause);
				break;
			case "game.play":
				ChangeState (States.Playing);
				break;
			case "game.restart":
				Debug.Log ("Restart");
				ChangeState (States.Restart);
				break;
			    
            default:
                ChangeToPreviousState();
                break;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) &&
          (GetCurrentState().Equals(States.Playing) || GetCurrentState().Equals(States.Pause)))
            //Toggle Pause State
            ChangeState(GetCurrentState().Equals(States.Pause) ? States.Playing : States.Pause);
    }

    public void Play()
    {
        ChangeState(States.Playing);
    }

    public static bool IsPlaying()
    {
        return Instance.GetCurrentState().Equals(States.Playing);
    }
}
