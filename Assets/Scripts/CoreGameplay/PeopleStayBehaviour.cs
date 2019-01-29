using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleStayBehaviour : MonoBehaviour 
{
    private NavMeshAgent mNavMeshAgent;

    private void Start () 
	{
        if (GetComponent<NavMeshAgent>() != null)
        {
            mNavMeshAgent = GetComponent<NavMeshAgent>();
            mNavMeshAgent.velocity = Vector3.zero;
            mNavMeshAgent.isStopped = true;
        }
	}
	
	private void Update () 
	{
		transform.rotation = Quaternion.identity;
    }
}
