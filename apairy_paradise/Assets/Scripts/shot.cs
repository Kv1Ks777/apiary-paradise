using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public GameObject prefab; // Префаб, который будет создаваться
    public float spawnInterval = 1.0f; // Интервал создания префабов в секундах

    // Start is called before the first frame update
    void Start()
    {
        // Запускаем корутину для создания префабов
        StartCoroutine(SpawnPrefabs());
    }

    // Корутину для создания префабов с заданным интервалом
    IEnumerator SpawnPrefabs()
    {
        while (true)
        {
            // Создаем префаб в позиции объекта, к которому прикреплен этот скрипт
            Instantiate(prefab, transform.position, Quaternion.identity);

            // Ждем заданный интервал перед следующим созданием префабов
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}