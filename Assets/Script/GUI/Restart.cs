using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Restart : StateComponentBase<GameManager>
{

	[SerializeField]
	GameObject resultUI;

	public override void EnterState()
	{
		resultUI.SetActive (false);
        Application.LoadLevel("Game");
    }

	public override void ExitState()
	{
        Time.timeScale = 1;
    }

	private void Update()
	{
	}
}
