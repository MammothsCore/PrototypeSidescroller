using UnityEngine;

public class Enemy_Senses : MonoBehaviour
{
    [SerializeField] private EnemyConfig config;

    [SerializeFiele] private Transform groundCheck;

    [SerializeFilde] private Transform wallCheck;

    public bool IsGrounded()
    {
        return !Physics2D.Raycast(groundCheck.position, Vector2.down, config.groundCheckDistance, config.groundLayer);
    }

    public bool IsWalled()
    {
        return Physics2D.Raycast(wallCheck.position, Vector2.down, config.wallCheckDistance, config.wallLayer);
    }
}
