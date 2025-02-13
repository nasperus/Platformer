using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] private Animator animator;
    private static readonly int EnemyMove = Animator.StringToHash("Move");


    public void MoveAnimation()
    {
        animator.SetTrigger(EnemyMove);
    }
    
}
