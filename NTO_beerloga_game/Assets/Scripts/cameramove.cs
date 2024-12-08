using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameramove : MonoBehaviour
{
    public Transform player; // ������ �� ������ ������
    public float smoothSpeed = 0.125f; // �������� �����������
    public Vector3 offset; // �������� ������ ������������ ������
    public float cameraHeight = -10f; // ������ ������ �� ��� Z

    void LateUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        desiredPosition.z = cameraHeight; // ������������� ������������� ������ ������
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}



