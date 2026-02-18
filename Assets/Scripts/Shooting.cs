using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce;



    void Shoot()
    {
        GameObject Arrow = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = Arrow.GetComponent<Rigidbody2D>();
      rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}