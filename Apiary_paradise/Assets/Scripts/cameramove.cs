using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform player; // Ссылка на объект игрока
    public float smoothSpeed = 0.125f; // Скорость сглаживания
    public Vector3 offset; // Смещение камеры относительно игрока
    public float cameraHeight = -10f; // Высота камеры по оси Z

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        desiredPosition.z = cameraHeight; // Устанавливаем фиксированную высоту камеры
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}



