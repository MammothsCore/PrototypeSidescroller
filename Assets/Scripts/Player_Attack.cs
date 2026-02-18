using UnityEngine;
using UnityEngine.UI;
public class Player_Attack : MonoBehaviour
{
    public Animator anim;

    //public void Attack()
    //{
    //    anim.SetBool("isAttacking", true);
    //}
    //public void StopAttack()
    //{
    //    anim.SetBool("isAttacking", false);
    //}

    public void AttackLeft()
    {
       anim.SetBool("isAttackingLeft", true);
    }


    public void AttackRight()
    {
         anim.SetBool("isAttackingRight", true);
        
    }

    public void AttackUp()
    {
        anim.SetBool("isAttackingUp", true);
        
    }

    public void AttackDown()
    {
        anim.SetBool("isAttackingDown", true);
       
    }

    public void ResetAttack()
    {
        anim.SetBool("isAttackingLeft", false);
        anim.SetBool("isAttackingRight", false);
        anim.SetBool("isAttackingUp", false);
        anim.SetBool("isAttackingDown", false);
    }

}
