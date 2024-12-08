using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osa : MonoBehaviour
{
    public Transform targetPrefab; // ������� ������, � �������� ����� ��������� ������
    public Transform collisionPrefab; // ������, � ������� ����� ����������� ������������
    public float speed = 5f; // �������� �������� �������

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // ������� ������ � ������� �������� �������
        if (targetPrefab != null)
        {
            Vector3 direction = (targetPrefab.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    // ��������� ������������ � ������ ��������
    void OnTriggerEnter(Collider other)
    {
        if (other.transform == collisionPrefab)
        {
            // �������� ��� ������������ � ������ ��������
            Debug.Log("������������ � ��������!");
            // ��������, ����� ���������� ������
            Destroy(gameObject);
        }
    }
}