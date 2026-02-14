using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damge = 1;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;

private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        { 
            collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damge);
        }
    }

    public void Attack()
        {
    // Implement attack logic here, such as playing an animation or dealing damage to the player.
    Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
    if(hits.Length > 0)
    {
        hits[0].GetComponent<PlayerHealth>().ChangeHealth(-damge);
    }
     }
}
