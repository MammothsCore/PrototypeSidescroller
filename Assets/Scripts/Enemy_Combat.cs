using UnityEngine;

public class Enemy_Combat : MonoBehaviour
{
    public int damge = 1;
    private void OnCollisionEnter2D(Collision2D collision)


    {
        collision.gameObject.GetComponent<PlayerHealth>().ChangeHealth(-damge);
    }
}
