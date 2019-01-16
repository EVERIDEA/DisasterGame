using System;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
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

	void Awake()
	{
		EventManager.AddListener<MovePlayerEvents>(MoveHandler);
		EventManager.AddListener<OnMoveEvents>(OnMoveHandler);
		EventManager.AddListener<PlayerActionEvents>(ActionHandler);
	}

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
		if (OnMove) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Debug.Log(mousePos);
				mousePos2d = new Vector2(mousePos.x, mousePos.y);
				mousePos.z = transform.position.z;
				RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
				if (hit.transform == null) 
				{
					move = true;
					return;
				}
				if ((hit.transform.gameObject.tag=="People")&&(move==false))
				{
					move = true;
					return;
				}
				else
				{
					move = false;
					return;
				}
			}

			if (move==true) 
			{
				transform.position = Vector3.MoveTowards (transform.position, mousePos, speed * Time.deltaTime);
			}

		}

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

	private void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag=="People") 
		{
			EventManager.TriggerEvent (new PlayerActionEvents (true));
		}
	}

	private void OnTriggerExit2D(Collider2D c)
	{
		if (c.gameObject.tag=="People") 
		{
			EventManager.TriggerEvent (new PlayerActionEvents (false));
		}
	}
}
