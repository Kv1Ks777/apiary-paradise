using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovment : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f; // Скорость при ускорении
    public AudioSource movementAudioSource; // AudioSource для звука передвижения
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Проверка столкновений с помощью Raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1f);
        if (hit.collider != null)
        {
            // Обработка столкновения
            Debug.Log("Столкновение с " + hit.collider.name);
        }
        // Получаем ввод от пользователя
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        // Проверяем, есть ли движение
        if (movement != Vector2.zero)
        {
            // Если звук не проигрывается, запускаем его
            if (!movementAudioSource.isPlaying)
            {
                movementAudioSource.Play();
            }
        }
        else
        {
            // Если движение остановилось, останавливаем звук
            if (movementAudioSource.isPlaying)
            {
                movementAudioSource.Stop();
            }
        }
    }

    void FixedUpdate()
    {
        // Проверяем, удерживается ли клавиша Shift
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;

        // Перемещаем игрока
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }
}