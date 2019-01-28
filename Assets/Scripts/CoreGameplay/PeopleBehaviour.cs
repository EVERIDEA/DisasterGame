using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PeopleBehaviour : MonoBehaviour 
{
	private NavMeshAgent mNavMeshAgent;
	private float checkRate;
	private float nextCheck;
	private float wanderRange = 10;
	private Transform myTransform;
	private NavMeshHit navHit;
	private Vector3 wanderTarget;
	private bool IsWander=true;

	private void OnEnable()
	{
        EventManager.AddListener<PeopleMoveEvents>(PeopleMoveHandler);
        SetInitialReference ();
    }

    private void OnDisable()
    {
        EventManager.RemoveAllListeners();
    }


    private void Awake()
	{
		
	}

	private void Update()
	{
		transform.rotation = Quaternion.identity;
		if (Time.time>nextCheck) 
		{
			nextCheck = Time.time + checkRate;
			if (IsWander==true) 
			{
				CheckIfIShouldWander ();
			}
		}
	}


	void SetInitialReference()
	{
		if (GetComponent<NavMeshAgent>()!=null) 
		{
			mNavMeshAgent = GetComponent<NavMeshAgent> ();
		}
		checkRate = Random.Range (0.3f, 0.4f);
		myTransform = transform;
	}

	void CheckIfIShouldWander()
	{
		if (RandomWanderTarget (myTransform.position,wanderRange,out wanderTarget)) 
		{
			mNavMeshAgent.SetDestination (wanderTarget);
		}
	}

	bool RandomWanderTarget(Vector3 center,float range, out Vector3 result)
	{
		Vector3 randomPoint = center + Random.insideUnitSphere * wanderRange;
		if (NavMesh.SamplePosition (randomPoint,out navHit, 1.0f,NavMesh.AllAreas)) 
		{
			result = navHit.position;
			return true;
		} 
		else 
		{
			result = center;
			return false;
		}
	}


	void PeopleMoveHandler(PeopleMoveEvents e)
	{
		if (e.Wander) 
		{
			IsWander = true;
		} 
		else 
		{
			IsWander = false;	
		}
	}
}
