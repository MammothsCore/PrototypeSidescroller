using UnityEngine;
using UnityEngine.UI;
public class Player_Attack : MonoBehaviour
{
    public Animator anim;
  
        public void Attack()
    {
        anim.SetBool("isAttacking", true);
}
    public void StopAttack()
    {
        anim.SetBool("isAttacking", false);
    }
}
