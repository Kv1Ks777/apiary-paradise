using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osa : MonoBehaviour
{
    public Transform targetPrefab; // Целевой префаб, к которому будет двигаться объект
    public Transform collisionPrefab; // Префаб, с которым будет проверяться столкновение
    public float speed = 5f; // Скорость движения объекта

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Двигаем объект в сторону целевого префаба
        if (targetPrefab != null)
        {
            Vector3 direction = (targetPrefab.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // Обработка столкновения с другим префабом
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == collisionPrefab)
        {
            // Действия при столкновении с другим префабом
            Debug.Log("Столкновение с префабом!");
            // Например, можно уничтожить объект
            Destroy(gameObject);
        }
    }
}