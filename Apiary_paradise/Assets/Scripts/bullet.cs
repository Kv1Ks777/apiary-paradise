using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        // Здесь можно добавить логику для нанесения урона игроку или другим объектам
        Destroy(gameObject);
    }
}