using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptPlatform : MonoBehaviour
{
    public float velocity = 2;
    public float radiusX = 1;
    public float radiusY = 1;
    
    private float _count =  0;
    private Vector2 _initialPos;
    
    // Start is called before the first frame update
    void Start()
    {
        _initialPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
    }

    private void Move()
    {
        _count += velocity * Time.deltaTime;
        float xPos = Mathf.Cos(_count) * radiusX;
        float yPos = Mathf.Sin(_count) * radiusY;
        
        Vector2 newPosition = new Vector2(xPos, yPos);
        transform.position = _initialPos + newPosition;

        if (_count >= 2 * Mathf.PI)
        {
            _count = Convert.ToSingle(2 * Math.PI - _count) ;
        }
    }
}
