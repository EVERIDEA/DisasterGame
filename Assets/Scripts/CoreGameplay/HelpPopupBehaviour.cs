using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpPopupBehaviour : MonoBehaviour 
{
	public int HelpId;

	private void OnEnable()
	{
		this.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled=true;
	}

	private void OnDisable()
	{
		this.transform.parent.gameObject.GetComponent<BoxCollider2D>().enabled=false;
	}
}
