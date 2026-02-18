using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject arrowUp;
    public GameObject arrowDown;
    public GameObject arrowLeft;
    public GameObject arrowRight;

    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointLeft;
    public Transform firePointRight;
    public float bulletForce;



    void ShootDown()
    {
        GameObject ArrowDown = Instantiate(arrowDown, firePointDown.position, firePointDown.rotation);
        Rigidbody2D rb = ArrowDown.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointDown.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootUp()
    {
        GameObject ArrowUp = Instantiate(arrowUp, firePointUp.position, firePointUp.rotation);
        Rigidbody2D rb = ArrowUp.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointUp.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootLeft()
    {
        GameObject ArrowLeft = Instantiate(arrowLeft, firePointLeft.position, firePointLeft.rotation);
        Rigidbody2D rb = ArrowLeft.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointLeft.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootRight()
    {
        GameObject ArrowRight = Instantiate(arrowRight, firePointRight.position, firePointRight.rotation);
        Rigidbody2D rb = ArrowRight.GetComponent<Rigidbody2D>();
        rb.AddForce(firePointRight.up * bulletForce, ForceMode2D.Impulse);
    }

}