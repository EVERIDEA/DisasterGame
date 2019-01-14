using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameStateAccess : BaseBehaviour
{
	protected override void OnAwake () => base.OnAwake ();

	protected override void OnState (System.Boolean enable)
	{
		if (enable)
		{
			SignalManager.Instance.AttachReceiver ("state.alter" , this.OnSignalReceived);
		}
	}

	private void OnSignalReceived (Dictionary<System.String , System.Object> parameters)
	{
		var action = (String) parameters ["action"];
		var type = (String) parameters ["type"];
		var value = String.Empty;

		if (String.CompareOrdinal (action , "set") == 0)
		{
			value = (String) parameters ["value"];
		}
        
		switch (action)
		{
			case "get":
			{
				switch (type)
				{
					case "boolean":
						Debug.Log ($@"The Boolean value : {GameplayManager.Instance.GetState<Boolean> ("test.bool")}");
						break;
					case "int32":
						Debug.Log ($@"The Int32 value : {GameplayManager.Instance.GetState<Int32> ("test.int32")}");
						break;
                    case "playerstatus":
                            PlayerStatus player = GameplayManager.Instance.GetState<PlayerStatus>("test.playerstatus");
                            Debug.Log($@"Get Player Status : {player}");
                        break;
                            
				}
			}
			break;
			case "set":
			{
                switch (type)
                {
                    case "boolean":
                        {
                            var parsed = Boolean.Parse(value);
                            Debug.Log($@"The Boolean value : {parsed} should be set!");
                            GameplayManager.Instance.SetState<Boolean>("test.bool", parsed);
                        }
                        break;
                    case "int32":
                        {
                            var parsed = Int32.Parse(value);
                            Debug.Log($@"The Int32 value : {parsed} should be set!");
                            GameplayManager.Instance.SetState<Int32>("test.int32", parsed);
                        }
                        break;
                    case "playerstatus":
                        {
                            var player = new PlayerStatus("sex", 100, 100);
                            GameplayManager.Instance.SetState<PlayerStatus>("test.playerstatus", player);
                            Debug.Log($@"Set Player Status : {player.Id}");
                        }
                        break;
                    }
			}
			break;
		}
	}
}