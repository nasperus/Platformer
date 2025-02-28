using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(BoxCollider2D), typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{ 
    public static Enemy Instance;
    private EnemyAnimations _enemyAnimations;
 [SerializeField] private Transform firstObject;
 [SerializeField] private Transform secondObject;
 [SerializeField] private float moveSpeed;
 [SerializeField] private SpriteRenderer spriteRenderer;

 private bool _toggleObjects = true;

 private void Awake()
 {
     Instance = this;
     _enemyAnimations = GetComponent<EnemyAnimations>();
 }

 private void Update()
 {
  EnemyMovement();
 }


 private void EnemyMovement()
 {
     var target = _toggleObjects ? firstObject : secondObject;
     transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
     _enemyAnimations.MoveAnimation();
     if (!(Vector3.Distance(transform.position, target.position) < 0.1f)) return;
     _toggleObjects = !_toggleObjects;
     spriteRenderer.flipX = !_toggleObjects;
    
 }

 private void TestingHub()
 {
     Debug.Log("asdasd");
 }
}
