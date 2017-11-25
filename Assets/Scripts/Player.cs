using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D _rigibody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private LayerMask _groundLayers;
    private float _groundCheckRadious;
    private bool _isOnGround;
    private Transform _groundCheck;

    [SerializeField]
    private float _moveSpeed = 5.0f;

    [SerializeField]
    private float _jumpHeight = 12.0f;

    void Start()
	{
	    _rigibody = GetComponent<Rigidbody2D>();
	    _animator = GetComponent<Animator>();
	    _spriteRenderer = GetComponent<SpriteRenderer>();

        _groundLayers = LayerMask.GetMask("Ground");
	    _groundCheckRadious = 0.25f;
	    _isOnGround = false;
	    _groundCheck = this.transform.Find("GroundCheck");
	}
	
	void Update()
    {
        Move();
        Jump();
    }

    private void Jump()
    {
        _isOnGround = Physics2D.OverlapCircle(_groundCheck.position,
            _groundCheckRadious,
            _groundLayers);

        _animator.SetBool("IsOnGround", _isOnGround);

        if (Input.GetButtonDown("Jump") && _isOnGround)
        {
            _rigibody.velocity = new Vector2(_rigibody.velocity.x, _jumpHeight);
        }
    }

    private void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            _rigibody.velocity = new Vector2(_moveSpeed, _rigibody.velocity.y);
            transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z, transform.rotation.w);
        }
        else if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            _rigibody.velocity = new Vector2(-_moveSpeed, _rigibody.velocity.y);
            transform.rotation = new Quaternion(transform.rotation.x, 180, transform.rotation.z, transform.rotation.w);
        }
        else
        {
            _rigibody.velocity = new Vector2(0.0f, _rigibody.velocity.y);
        }

        _animator.SetFloat("Speed", Mathf.Abs(_rigibody.velocity.x));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Spikes"))
        {
            SceneManager.LoadScene("menu");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
            transform.parent = other.transform;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovingPlatform")
            transform.parent = null;
    }
}
