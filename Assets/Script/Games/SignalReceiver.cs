using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SignalReceiver : BaseBehaviour
{
	public System.String [] Signal;
    
    System.Boolean test = false;

	protected override void OnStart ()
	{
        for (int i = 0; i < Signal.Length; i++)
		    SignalManager.Instance.AttachReceiver (this.Signal[i] , this.OnSignalReceived);
	}

	private void OnSignalReceived (Dictionary<System.String , System.Object> parameters)
	{
		Debug.Log ("Signal received!");

		for (var c = 0 ; c < parameters.Keys.Count ; c++)
		{
			Debug.Log ($@"{parameters.Keys.ElementAt (c)}, {parameters.Values.ElementAt (c)}");

            System.Boolean x = System.Boolean.Parse (parameters.Values.ElementAt(c).ToString());
            test = x;
        }
	}
}