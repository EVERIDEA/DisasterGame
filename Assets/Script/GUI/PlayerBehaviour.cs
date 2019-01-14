using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField]
    float speed; 

    Rigidbody2D riggidBody;      

    // Use this for initialization
    void Start()
    {
        riggidBody = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {

    }
}
