using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPump : MonoBehaviour
{
    public GameObject honeyPumpPrefab; // Префаб honey_pump
    public static int energy_honey_per_day = 0;
    public Sprite defaultSprite; // Самый изначальный спрайт
    public Sprite sprite1; // Спрайт для увеличения на 150
    public Sprite sprite2; // Спрайт для увеличения на 250

    public void SpawnHoneyPump(Vector3 position)
    {
        // Создаем префаб honey_pump
        Instantiate(honeyPumpPrefab, position, Quaternion.identity);

        // Увеличиваем глобальную переменную
        energy_honey_per_day += 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Увеличиваем глобальную переменную на 100 единиц
        energy_honey_per_day += 100;

        // Устанавливаем начальный спрайт
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            if (spriteRenderer.sprite == null)
            {
                spriteRenderer.sprite = defaultSprite;
            }

            // Проверяем спрайт объекта и увеличиваем переменную в зависимости от спрайта
            if (spriteRenderer.sprite == sprite1)
            {
                energy_honey_per_day += 150;
            }
            else if (spriteRenderer.sprite == sprite2)
            {
                energy_honey_per_day += 250;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}