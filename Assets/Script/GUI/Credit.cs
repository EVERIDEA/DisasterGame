using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Credit : StateComponentBase<Menu>
{
    [SerializeField]
    private GameObject creditPanel;

    public override void EnterState()
    {
        Behaviour.ToggleButtons(false);
        creditPanel.SetActive(true);
    }

    public override void ExitState()
    {
        Behaviour.ToggleButtons(true);
        creditPanel.SetActive(false);
    }

    public void GoBack()
    {
        Behaviour.ChangeToPreviousState();
    }
}
