using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f; // �������� ��� ���������
    public AudioSource movementAudioSource; // AudioSource ��� ����� ������������
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // �������� ������������ � ������� Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null)
        {
            // ��������� ������������
            Debug.Log("������������ � " + hit.collider.name);
        }
        // �������� ���� �� ������������
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // ���������, ���� �� ��������
        if (movement != Vector2.zero)
        {
            // ���� ���� �� �������������, ��������� ���
            if (!movementAudioSource.isPlaying)
            {
                movementAudioSource.Play();
            }
        }
        else
        {
            // ���� �������� ������������, ������������� ����
            if (movementAudioSource.isPlaying)
            {
                movementAudioSource.Stop();
            }
        }
    }

    void FixedUpdate()
    {
        // ���������, ������������ �� ������� Shift
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        // ���������� ������
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}