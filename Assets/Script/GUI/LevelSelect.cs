using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelect : StateComponentBase<Menu>
{
    [SerializeField]
    private GameObject panelUI;
    
    public override void EnterState()
    {
        Behaviour.ToggleButtons(false);
        panelUI.SetActive(true);
    }

    public override void ExitState()
    {
        Behaviour.ToggleButtons(true);
        panelUI.SetActive(false);
    }

    public void GoBack()
    {
        Behaviour.ChangeToPreviousState();
    }

}
