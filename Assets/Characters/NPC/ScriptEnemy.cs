﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemy : MonoBehaviour
{
    public float velocity = 2;
    public float distance = 0.5f;
    public LayerMask layerMask;
    public LayerMask pcLayerMask;

    private Rigidbody2D _rigidbody2D;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.ChangeDirection();
        this.HitPC();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(velocity, 0);
    }

    private void ChangeDirection()
    {
        RaycastHit2D hit2D;
        hit2D = Physics2D.Raycast(this.transform.position, this.transform.right, this.distance, layerMask);
        if (hit2D.collider != null)
        {
            velocity = velocity * -1;
            _rigidbody2D.velocity = new Vector2(velocity, 0);
            transform.Rotate(new Vector2(0, 180));
        }
    }

    private void HitPC()
    {
        Vector3 position = transform.position;

        RaycastHit2D hit2DRight, hit2DLeft;
        hit2DRight = Physics2D.Raycast(position, transform.right, this.distance, pcLayerMask);
        hit2DLeft = Physics2D.Raycast(position, -transform.right, this.distance, pcLayerMask);
        if (hit2DRight.collider != null || hit2DLeft.collider != null)
        {
            Destroy(hit2DRight.collider.gameObject);
            Destroy(hit2DLeft.collider.gameObject);
        }
    }
}