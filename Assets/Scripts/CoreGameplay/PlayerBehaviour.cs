using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;
public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed; 
	bool move=false;
	Vector2 mousePos2d;
	Vector3 mousePos;
    Rigidbody2D rigidBody; 
	bool OnMove=true;
	public GameObject Action;
	public Button ActionButton;
	private NavMeshAgent mNavMeshAgent;
	private bool mRunning;

	void Awake()
	{
		EventManager.AddListener<MovePlayerEvents>(MoveHandler);
		EventManager.AddListener<OnMoveEvents>(OnMoveHandler);
		EventManager.AddListener<PlayerActionEvents>(ActionHandler);
	}

    void Start()
    {
		mNavMeshAgent = GetComponent<NavMeshAgent> ();
    }
    
    void Update()
    {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit hit;

		if (Input.GetMouseButton (0)) 
		{
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

		transform.rotation = Quaternion.identity;

    }

	void MoveHandler(MovePlayerEvents e)
	{
		if (e.IsMove==true) 
		{
			move = true;
		} 
		else if (e.IsMove==false) 
		{
			move = false;
		}
	}

	void OnMoveHandler(OnMoveEvents e)
	{
		if (e.OnMove==false) 
		{
			OnMove = false;
		} 
		else if (e.OnMove==true) 
		{
			OnMove = true;
		}
	}

	void ActionHandler(PlayerActionEvents e)
	{
		if (e.IsActive==true) 
		{
			Action.SetActive (true);
			ActionButton.onClick.AddListener (delegate
				{
					Debug.Log ("Action");
					EventManager.TriggerEvent (new RandomQuizEvents ());
					move=true;
					OnMove=false;
			});
		} 
		else if (e.IsActive==false) 
		{
			Action.SetActive (false);
		}
	}

	private void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.tag=="People")
		{
			EventManager.TriggerEvent (new PlayerActionEvents (true));
			Global.PeopleId = c.gameObject.GetComponentInChildren<HelpPopupBehaviour> ().HelpId;
		}

	}

	private void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag=="People") 
		{
			EventManager.TriggerEvent (new PlayerActionEvents (false));
			Global.PeopleId = 0;
		}
	}
}
