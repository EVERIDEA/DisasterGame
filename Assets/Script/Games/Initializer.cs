using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Initializer : BaseBehaviour
{
	protected override void OnAwake ()
	{
		base.OnAwake ();

		GameplayManager.Initialize();
        SignalManager.Initialize();
	}
}