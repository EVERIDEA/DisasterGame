using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GUIControllerMain : BaseBehaviour
{
	public void OnActionSimple (String action)
	{
		switch (action.ToLower ())
		{
			case "debug.show":
			{
				Debug.Log ($@"Message generated {DateTime.Now}, from Simple");
			}
			break;
		}
	}

	public void OnActionAdvanced (String identifier)
	{
		if (String.IsNullOrEmpty (identifier) || String.IsNullOrWhiteSpace (identifier))
		{
			return;
		}

		var data = identifier.Split (new [] { ":" } , StringSplitOptions.RemoveEmptyEntries);
		var key = String.Empty;
		var val = String.Empty;

		if (data.Length > 1)
		{
			var param = data [1].Split (new [] { "=" } , StringSplitOptions.RemoveEmptyEntries);
			key = param [0];
			val = param [1];
		}

		switch (data [0].ToLower ())
		{
			case "debug.show":
			{
				if (String.CompareOrdinal (key , "message") == 0 && !String.IsNullOrEmpty (val))
				{
					Debug.Log ($@"Message was : {val}");
				}
				else
				{
					Debug.Log ($@"Generated message {DateTime.Now}, from Advanced");
				}
			}
			break;
		}
	}
}