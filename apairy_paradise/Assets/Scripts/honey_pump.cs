using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoneyPump : MonoBehaviour
{
    public GameObject honeyPumpPrefab; // ������ honey_pump
    public static int energy_honey_per_day = 0;
    public Sprite defaultSprite; // ����� ����������� ������
    public Sprite sprite1; // ������ ��� ���������� �� 150
    public Sprite sprite2; // ������ ��� ���������� �� 250

    public void SpawnHoneyPump(Vector3 position)
    {
        // ������� ������ honey_pump
        Instantiate(honeyPumpPrefab, position, Quaternion.identity);

        // ����������� ���������� ����������
        energy_honey_per_day += 5;
    }

    // Start is called before the first frame update
    void Start()
    {
        // ����������� ���������� ���������� �� 100 ������
        energy_honey_per_day += 100;

        // ������������� ��������� ������
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            if (spriteRenderer.sprite == null)
            {
                spriteRenderer.sprite = defaultSprite;
            }

            // ��������� ������ ������� � ����������� ���������� � ����������� �� �������
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