using Cainos.PixelArtPlatformer_VillageProps;
using UnityEngine;
using UnityEngine.InputSystem;
using Cainos.PixelArtPlatformer_VillageProps;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    
    public float moveSpeed = 8f;
    public float jumpForce = 12f;

    [Header("Ground Check (no tags/layers)")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.15f;

    private Rigidbody2D rb;
    private Collider2D myCollider;
    private bool isGrounded;

    private readonly Collider2D[] hitBuffer = new Collider2D[8];

    [Header("Interaction")]
    public Text pressEText;           // im Inspector zuweisen
    private Chest currentChest;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<Collider2D>();

        // Auto-create GroundCheck if not assigned
        if (groundCheck == null)
        {
            GameObject gc = new GameObject("GroundCheck");
            gc.transform.SetParent(transform);
            gc.transform.localPosition = new Vector3(0f, -0.6f, 0f);
            groundCheck = gc.transform;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        var chest = other.GetComponent<Chest>();
        if (chest != null)
        {
            currentChest = chest;
            ShowPressE(true);
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        var chest = other.GetComponent<Chest>();
        if (chest != null && currentChest == chest)
        {
            currentChest = null;
            ShowPressE(false);
        }
    }

    private void ShowPressE(bool show)
    {
        if (pressEText != null)
            pressEText.gameObject.SetActive(show);
    }
    private void Update()
    {
        UpdateGrounded();
        Move();
        Jump();
        Interact();
    }
    private void Interact()
    {
        if (Keyboard.current.eKey.wasPressedThisFrame && currentChest != null)
        {
            // Toggle
            if (currentChest.IsOpened) currentChest.Close();
            else currentChest.Open();
        }
    }
    private void UpdateGrounded()
    {
        isGrounded = false;

        int count = Physics2D.OverlapCircleNonAlloc(groundCheck.position, groundCheckRadius, hitBuffer);
        for (int i = 0; i < count; i++)
        {
            Collider2D c = hitBuffer[i];
            if (c == null) continue;

            // ignore own collider (and triggers)
            if (c == myCollider) continue;
            if (c.isTrigger) continue;

            isGrounded = true;
            return;
        }
    }

    private void Move()
    {
        float moveInput = 0f;
        if (Keyboard.current.leftArrowKey.isPressed) moveInput = -1f;
        if (Keyboard.current.rightArrowKey.isPressed) moveInput = 1f;

        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void Jump()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck == null) return;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    
    
   
}