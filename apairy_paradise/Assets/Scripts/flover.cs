using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем нажатие на объект
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                CollectFlower();
            }
        }
    }

    void CollectFlower()
    {
        GameData.flowers++; // Увеличиваем количество цветов
        Destroy(gameObject); // Удаляем объект
    }
}