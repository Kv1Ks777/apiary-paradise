using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turelcontroler : MonoBehaviour
{
    public Transform player; // ������ �� ������
    public GameObject bulletPrefab; // ������ ����
    public Transform firePoint; // �����, �� ������� ����� �������� ����
    public float fireRate = 1f; // �������� �������� (��������� � �������)
    public float bulletSpeed = 10f; // �������� ����

    private float nextFireTime = 0f;

    void Update()
    {
        // ������� ������ � ������� ������
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // ��������
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = firePoint.right * bulletSpeed;
    }
}
