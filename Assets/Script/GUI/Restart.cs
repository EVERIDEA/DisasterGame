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
		Debug.Log ("Keluar Ga");
	}
	public override void ExitState()
	{

	}

	private void Update()
	{
	}
}
