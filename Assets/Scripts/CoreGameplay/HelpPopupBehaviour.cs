using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HelpPopupBehaviour : MonoBehaviour 
{
	public int HelpId;

	private void OnEnable()
	{
		this.transform.parent.gameObject.GetComponent<BoxCollider>().enabled=true;
		this.transform.parent.gameObject.GetComponent<NavMeshAgent>().enabled=true;
		this.transform.parent.gameObject.AddComponent<PeopleBehaviour>();
	}

	private void OnDisable()
	{
		this.transform.parent.gameObject.GetComponent<BoxCollider>().enabled=false;
		this.transform.parent.gameObject.GetComponent<NavMeshAgent>().enabled=false;
		PeopleBehaviour Remove = this.transform.parent.gameObject.GetComponent<PeopleBehaviour>();
		Destroy(Remove);
	}
}
