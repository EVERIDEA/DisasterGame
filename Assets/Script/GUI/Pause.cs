using UnityEngine;
using System.Collections;

public class Pause : StateComponentBase<GameManager>
{
    [SerializeField]
    GameObject pauseUI;

    public override void EnterState()
    {
        Time.timeScale = 0;
        pauseUI.SetActive(true);
    }
    public override void ExitState()
    {
        Time.timeScale = 1;
        pauseUI.SetActive(false);
    }

    private void Update()
    {
    }
}
