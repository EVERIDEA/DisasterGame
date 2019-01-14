using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataUIClass
{
    public GameObject DisplayObjectHUD;
    public string Tag;
}

public class ObjectData : MonoBehaviour
{
    [SerializeField]
    bool _IsTest;

    [SerializeField]
    DataUIClass[] _DisplayList;

    Dictionary<string, GameObject> _ListOfDataUI = new Dictionary<string, GameObject>();

    
    // Use this for initialization
    void Awake ()
    {
        EventManager.AddListener<MainMenuButtonEvent>(MainMenuButtonListener);

        foreach(DataUIClass x in _DisplayList)
        {
            _ListOfDataUI.Add(x.Tag, x.DisplayObjectHUD);
        }
    }

    private void Start()
    {

    }

    void MainMenuButtonListener(MainMenuButtonEvent e)
    {
        switch(e.Type)
        {
            case EMainMenuButton.PLAY:
                _ListOfDataUI["mainmenu"].SetActive(false);
                _ListOfDataUI["storymenu"].SetActive(true);
                break;
            case EMainMenuButton.HELP:
                _ListOfDataUI["helpinstruction"].SetActive(e.IsActive);
                break;
            case EMainMenuButton.EXIT:
                Debug.Log("EXIT BUTTON");
                break;
            case EMainMenuButton.PAUSE:
                _ListOfDataUI["pausemenu"].SetActive(e.IsActive);
                if(e.IsActive)
                    Time.timeScale = 0;
                else
                    Time.timeScale = 1;
                break;
            case EMainMenuButton.RESTART:
                foreach(var x in _ListOfDataUI)
                {
                    if(x.Key == "mainmenu")
                        x.Value.SetActive(true);
                    else
                        x.Value.SetActive(false);
                }
                break;
            case EMainMenuButton.START_GAME:
                _ListOfDataUI["storymenu"].SetActive(false);
                if(e.IsActive)
                {
                    _ListOfDataUI["gameplay"].SetActive(true);
                }
                else
                {
                    _ListOfDataUI["mainmenu"].SetActive(true);
                }
                break;
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
            MainMenuButtonListener(new MainMenuButtonEvent(EMainMenuButton.RESTART));
    }
}
