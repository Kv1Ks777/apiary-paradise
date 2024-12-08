using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventary : MonoBehaviour
{
    public Text energomedText; // ������ �� UI ����� ��� ����� ���������
    public Text flowersText; // ������ �� UI ����� ��� ������
    public Text woodText; // ������ �� UI ����� ��� ������

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI(); // ��������� UI ��� ������
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI(); // ��������� UI ������ ����
    }

    void UpdateUI()
    {
        // ������������ ���������� ����� ���������
        int energomedCells = GlobalVariables.energy_honey_balance / 10;

        energomedText.text = energomedCells.ToString();
        flowersText.text = GameData.flowers.ToString();
        woodText.text = GameData.wood.ToString();
    }
}