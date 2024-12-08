using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot : MonoBehaviour
{
    public GameObject prefab; // ������, ������� ����� �����������
    public float spawnInterval = 1.0f; // �������� �������� �������� � ��������

    // Start is called before the first frame update
    void Start()
    {
        // ��������� �������� ��� �������� ��������
        StartCoroutine(SpawnPrefabs());
    }

    // �������� ��� �������� �������� � �������� ����������
    IEnumerator SpawnPrefabs()
    {
        while (true)
        {
            // ������� ������ � ������� �������, � �������� ���������� ���� ������
            Instantiate(prefab, transform.position, Quaternion.identity);

            // ���� �������� �������� ����� ��������� ��������� ��������
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}