using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Result : StateComponentBase<GameManager>
{

	[SerializeField]
	GameObject resultUI;

	public override void EnterState()
	{
		resultUI.SetActive (true);
	}
	public override void ExitState()
	{
		resultUI.SetActive (false);
	}

	private void Update()
	{
	}
}
