using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPopupBehaviour : MonoBehaviour 
{
	public int HelpId;

	private void OnEnable()
	{
		this.transform.parent.gameObject.GetComponent<BoxCollider>().enabled=true;
	}

	private void OnDisable()
	{
		this.transform.parent.gameObject.GetComponent<BoxCollider>().enabled=false;
	}
}
