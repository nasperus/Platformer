using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerAnimations : MonoBehaviour
{
  [SerializeField] private Animator animator;
  private static readonly int IsMoving = Animator.StringToHash("IsMoving");
  private static readonly int IsJumping = Animator.StringToHash("IsJumping");
  private static readonly int YVelocity = Animator.StringToHash("yVelocity");
  private static readonly int Dash = Animator.StringToHash("Dash");
  private static readonly int Attack = Animator.StringToHash("Attack");
  
  private void Update()
  {
    if (!Player.Instance) return;
    PlayerAnimation();
  }

  private void PlayerAnimation()
  {
    animator.SetBool(IsMoving, Player.Instance.IsMoving);
    animator.SetBool(IsJumping, !Player.Instance.IsGrounded);
    animator.SetFloat(YVelocity, Player.Instance.YVelocity);
    animator.SetBool(Dash, Player.Instance.IsDashing);
    
  }

  public void AttackAnimation()
  {
    animator.SetTrigger(Attack);
  }
}


public class ADSASDa
{
  private int x = 5;
  private int y = 5;
  

  ADSASDa(int x, int y)
  {
    this.x = x;
    this.y = y;
  }
}