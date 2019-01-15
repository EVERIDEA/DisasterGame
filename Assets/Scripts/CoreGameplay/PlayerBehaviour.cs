using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed; 
	bool move=false;
	Vector2 mousePos2d;
	Vector3 mousePos;
    Rigidbody2D rigidBody; 
	bool IsMove;

	void Awake()
	{
		EventManager.AddListener<MovePlayerEvents>(MoveHandler);
	}

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
		if (IsMove) 
		{
			if (Input.GetMouseButtonDown (0)) 
			{
				mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Debug.Log(mousePos);
				mousePos2d = new Vector2(mousePos.x, mousePos.y);
				mousePos.z = transform.position.z;
				RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
				if (hit.transform == null) {
					move = true;
					return;
				}
				if ((hit.transform.gameObject.tag=="People")&&(move==false))
				{
					move = true;
				}
				else
				{
					move = false;
					return; //Fail
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

	private void OnTriggerEnter2D(Collider2D c)
	{
		if (c.gameObject.tag=="People") 
		{
			EventManager.TriggerEvent (new MovePlayerEvents (true));
			EventManager.TriggerEvent (new RandomQuizEvents ());

		}
	}
}
