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

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
		if (Input.GetMouseButtonDown (0)) 
		{
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Debug.Log(mousePos);
			mousePos2d = new Vector2(mousePos.x, mousePos.y);
			mousePos.z = transform.position.z;
			RaycastHit2D hit = Physics2D.Raycast(mousePos2d, Vector2.zero);
			if (hit.transform == null) {
				return;
			}
			if ((hit.transform.gameObject.tag=="People"))
			{
				if (move==false) 
				{
					move = true;
				}
			}
			else
			{
				return; //Fail
			}

		}
		if (move==true) 
		{
			transform.position = Vector3.MoveTowards (transform.position, mousePos, speed * Time.deltaTime);
			//move = false;
		}

    }
}
