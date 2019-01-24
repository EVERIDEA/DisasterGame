using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.EventSystems;
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed; 
	Vector2 mousePos2d;
	Vector3 mousePos;
    Rigidbody2D rigidBody; 
	public GameObject Action;
	public Button ActionButton;
	private NavMeshAgent mNavMeshAgent;
	private bool mRunning;
	private bool IsMove=true;

	void Awake()
	{
		EventManager.AddListener<PlayerActionEvents>(ActionHandler);
		EventManager.AddListener<PlayerMoveEvents>(MoveHandler);
	}

    void Start()
    {
		mNavMeshAgent = GetComponent<NavMeshAgent> ();
    }
    
    void Update()
    {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit;
		transform.rotation = Quaternion.identity;
		if (IsMove=true) 
		{
			if (Input.GetMouseButton (0)) 
			{
				if (EventSystem.current.IsPointerOverGameObject())
				{
					return;
				}

				if (Physics.Raycast (ray,out hit, 100))
				{
					mNavMeshAgent.destination = hit.point;
					Debug.Log (hit.point);
				}
			}

				if (mNavMeshAgent.remainingDistance<=mNavMeshAgent.stoppingDistance) 
				{
					mRunning = false;
				} 
				else 
				{
					mRunning = true;	
				}
		}
    }



	void ActionHandler(PlayerActionEvents e)
	{
		if (e.IsActive==true) 
		{
			Action.SetActive (true);
			mRunning = false;
			ActionButton.onClick.AddListener (delegate
				{
					IsMove=false;
					EventManager.TriggerEvent (new PeopleMoveEvents (false));
					Debug.Log ("Action");
					EventManager.TriggerEvent (new RandomQuizEvents ());
			});
		} 
		else if (e.IsActive==false) 
		{
			Action.SetActive (false);
		}
	}

	void MoveHandler(PlayerMoveEvents e)
	{
		if (e.Move) 
		{
			IsMove = true;
		} 
		else 
		{
			IsMove = false;	
		}
	}

	private void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag=="People")
		{
			EventManager.TriggerEvent (new PlayerActionEvents (true));
			Global.PeopleId = c.gameObject.GetComponentInChildren<HelpPopupBehaviour> ().HelpId;
			c.gameObject.GetComponent<NavMeshAgent> ().isStopped = true;
		}

	}

	private void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag=="People") 
		{
			EventManager.TriggerEvent (new PlayerActionEvents (false));
			Global.PeopleId = 0;
			c.gameObject.GetComponent<NavMeshAgent> ().isStopped = false;
		}
	}
}
