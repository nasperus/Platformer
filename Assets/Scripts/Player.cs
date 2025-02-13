using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

[RequireComponent(typeof(Rigidbody2D), typeof(PlayerInput), typeof(BoxCollider2D))]
public class Player : MonoBehaviour
{
    public static  Player Instance;
    private PlayerAnimations _animations;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashDuration;
    [SerializeField] private float dashCooldown;
    [SerializeField] private float attackTimer;
    [SerializeField] private float airMovementSpeed;
    [SerializeField] private float airGravityForce;
    [SerializeField] private float groundDistance; 
    [SerializeField] private LayerMask groundLayer;
    public bool IsMoving { get; private set; }
    public bool IsGrounded { get; private set; }
    public  bool IsDashing { get; private set; }
    public float YVelocity { get; private set; }
    public bool JumpAttacking { get; private set; }
    private int _attackSequence;
   
    private Vector2 _playerInput;
    private float _originalMoveSpeed;
    private float _originalGravity;
    private float _dashTimer;
    private float _dashCooldownTimer;
    private float _attackCooldownTimer;
    private bool _canAttack;
    private int _currentAttackCounter;
    
    private void Awake()
    {
       
        Instance = this;
        _originalMoveSpeed = moveSpeed;
        _originalGravity = rb.gravityScale;
        _animations = GetComponent<PlayerAnimations>();
    }
    private void FixedUpdate()
    {
        PlayerMovement();
        DashTimer();
        DashCooldown();
        AttackCooldown();
    }
    
    private void OnMove(InputValue value) {_playerInput = value.Get<Vector2>();}
    private void OnJump() {if (!IsGrounded) return;  rb.velocity = new Vector2(rb.velocity.x, jumpForce);}

    private void OnAttack()
    {
        if (!IsGrounded || _attackCooldownTimer > 0) return;
        _canAttack = true;
        _attackCooldownTimer = attackTimer;
        _animations.AttackAnimation();
    }
    
    private void AttackCooldown()
    {
        if (_attackCooldownTimer >= 0)
            _attackCooldownTimer -= Time.deltaTime;
        else _canAttack = false;

    }
    private void DashTimer()
    {
        if (!(_dashTimer > 0)) return;
        _dashTimer -= Time.deltaTime;
        if (_dashTimer <= 0)
            IsDashing = false;
    }
    private void DashCooldown()
    {
        if (_dashCooldownTimer > 0)
            _dashCooldownTimer -= Time.deltaTime;
    }
    private void OnDash()
    { 
        if (_dashCooldownTimer > 0 || IsDashing || !IsMoving) return;
            _dashTimer = dashDuration;
            _dashCooldownTimer = dashCooldown;
            IsDashing = true;
    }
    private void PlayerMovement()
    {
        IsGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundDistance, groundLayer);
        moveSpeed = IsDashing ? _originalMoveSpeed + dashSpeed :IsGrounded ? _originalMoveSpeed : _originalMoveSpeed - airMovementSpeed;
        rb.gravityScale = IsGrounded ? _originalGravity : _originalGravity + airGravityForce;
        rb.velocity = _canAttack ? Vector2.zero : new Vector2(_playerInput.x * moveSpeed, rb.velocity.y);
        YVelocity = rb.velocity.y;
        var moveDirection = new Vector2(_playerInput.x, 0).normalized;
        IsMoving = moveDirection != Vector2.zero;
        if (!IsMoving) return;
        transform.localScale = new Vector3(moveDirection.x,transform.localScale.y,transform.localScale.z);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = IsGrounded ? Color.green : Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * groundDistance);
    }
    
}




