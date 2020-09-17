using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class scriptPC : MonoBehaviour
{
    public float velocity = 10;
    public float jumpForce = 370;
    public LayerMask layerMask;
    public AudioSource jumpSound;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private bool _isOverGround = false;
    private bool _isGoingToRight = true;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _isOverGround = true;
        this.JumpingAnimation();
        
        transform.parent = other.collider.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        _isOverGround = false;
        this.JumpingAnimation();

        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        this.Move();
        this.Jump();
        this.KillEnemy();
        this.EndOfStage();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        // Starts the animation
        this.MoveAnimation(x);
        // Starts moving
        _rigidbody2D.velocity = new Vector2(x * velocity, _rigidbody2D.velocity.y);
    }

    private void MoveAnimation(double x)
    {
        _animator.SetBool(Animator.StringToHash("IsIdle"), x == 0);
        // Rotate the PC to the diretion
        if (_isGoingToRight && x < 0 || !_isGoingToRight && x > 0)
        {
            transform.Rotate(new Vector2(0, 180));
            _isGoingToRight = !_isGoingToRight;
        }
    }

    private void Jump()
    {
        if (_isOverGround &&
            (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.O) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        )
        {
            jumpSound.Play();
            _rigidbody2D.AddForce(new Vector2(0, this.jumpForce));
        }
    }

    private void JumpingAnimation()
    {
        _animator.SetBool(Animator.StringToHash("IsJumping"), !_isOverGround);
    }

    private void KillEnemy()
    {
        RaycastHit2D hit2D;
        hit2D = Physics2D.Raycast(transform.position, -transform.up, 0.5f, layerMask);
        if (hit2D.collider != null)
            Destroy(hit2D.collider.gameObject);
    }

    private void EndOfStage()
    {
        RaycastHit2D hit2D;
        hit2D = Physics2D.Raycast(this.transform.position, this.transform.right, 5f, LayerMask.GetMask("EndOfStage"));
        if (hit2D.collider != null)
        {
            scriptGame.PcWon = true;
            this._animator.SetBool(Animator.StringToHash("HasWon"), true);
            Time.timeScale = 0;
        }
    }
}