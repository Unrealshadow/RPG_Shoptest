using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _rigidBody2D;
    private Animator _animator;
    private AnimationStates _currentState;
    private Vector2 _movementVector;

    public float speed = 2f;

    //Animation states
    private enum AnimationStates
    {
        MCWalkUp,
        MCWalkDown,
        MCWalkLeft,
        MCWalkRight,
        MCIdle
    }

    private void Awake()
    {
        _rigidBody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void ChangeAnimationState(AnimationStates newState)
    {
        if (_currentState == newState) return;
        _animator.Play(newState.ToString());
        _currentState = newState;
    }

    private void Update()
    {
        GetInputs();
        if (Input.GetKey(KeyCode.A) ||
            Input.GetKey(KeyCode.D) ||
            Input.GetKey(KeyCode.W) ||
            Input.GetKey(KeyCode.S))
        {
            Move();
        }
        else
        {
            Stop();
        }

    }

    private void GetInputs()
    {
        _movementVector = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
            );
    }

    private void Move()
    {
        _rigidBody2D.velocity = _movementVector.normalized * speed * Time.deltaTime;
        if (_movementVector.x > 0)
        {
            ChangeAnimationState(AnimationStates.MCWalkRight);
        }
        else if (_movementVector.x < 0)
        {
            ChangeAnimationState(AnimationStates.MCWalkLeft);
        }
        else if (_movementVector.y > 0)
        {
            ChangeAnimationState(AnimationStates.MCWalkUp);
        }
        else if (_movementVector.y < 0)
        {
            ChangeAnimationState(AnimationStates.MCWalkDown);
        }
    }

    private void Stop()
    {
        _rigidBody2D.velocity = Vector2.zero;
        ChangeAnimationState(AnimationStates.MCIdle);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
