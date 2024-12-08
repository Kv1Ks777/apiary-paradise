using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bear1_script : MonoBehaviour
{
    public GameObject uiPanel; // ������ �� UI ������
    public Text uiText; // ������ �� UI �����
    public Button closeButton; // ������ �� ������ �������� ������
    private int clickCount = 0; // ������� ������
    private bool factsStarted = false; // ���� ��� �������� ������ ������ ������

    private string[] messages = new string[]
    {
"������!",
"������ ���� �� ��� ����� �������, ������� ������� ������� � ������� �� ���������",
"���� ����� ����, � �� �������� ����������",
"����� �� �������� ��� 10 ����� ������ ��������� � � ����� ���� ������ �� ��������!",
"���� ������������ ����� ���������",
"���",
"���� �� ���� ���� ��� ��� �������� ��������� ��������",
"���� ��� - ���������"
    };

    private string[] honeyFacts = new string[]
    {
"��� ������� �� ��������. � ������������ ���� �� ����� ��������� �����",
"����� ������ �������� ����� 2 ��������� ������, ����� ���������� 1 ���� ����",
"��� ������������� � �������� � ������� ������ ��������� ����� ����������������� ���������",
"� �������, ���� ����� ���������� 1/12 ������ ����� ���� �� ���� �����",
"��� ������ ������ ������ � ������ � ����������� �� ��������� �������",
"����� ������������ ���, ����� �������� ����, ����� ��� �������� ��������",
"��� ������������� � ������� ������ ��� ��������������� ���",
"��� �������� �������������, ������� �������� �������� � ������������",
"��� ����� ������������ ��� ����������� �������� �� �����",
"��� ������������ � ��������� ��������� ����� ����������� � ��������������� ���������"
    };

    // Start is called before the first frame update
    void Start()
    {
        uiPanel.SetActive(false); // �������� ������ ��� ������
        closeButton.onClick.AddListener(ClosePanel); // ��������� ���������� ������� �� ������ ��������
    }

    // Update is called once per frame
    void Update()
    {
        // ��������� ������� �� ������
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                OpenPanel();
            }
        }
    }

    void OpenPanel()
    {
        uiPanel.SetActive(true); // ���������� ������
        clickCount++;

        if (!factsStarted)
        {
            if (clickCount <= 4)
            {
                uiText.text = messages[clickCount - 1]; // ��������� ����� �� ������
            }
            else if (clickCount == 5)
            {
                int energomedCells = GlobalVariables.energy_honey_balance / 10;
                if (energomedCells < 10)
                {
                    uiText.text = messages[4]; // ���� ������������ ����� ���������
                    clickCount--; // ��������� clickCount �� ���� ������, ����� �������� ��������� ���������� �����
                }
                else
                {
                    GlobalVariables.energy_honey_balance -= 100; // ������� 10 ����� ��������� (100 ������ �������� ���������)
                    GlobalVariables.beekeeperRelations += 50; // ����������� ��������� � �����������
                    uiText.text = messages[5]; // ���
                }
            }
            else if (clickCount == 6)
            {
                uiText.text = messages[6]; // ���� �� ���� ���� ��� ��� �������� ��������� ��������
            }
            else if (clickCount == 7)
            {
                uiText.text = messages[7]; // ���� ��� - ���������
            }
            else if (clickCount >= 8)
            {
                factsStarted = true; // ������������� ����, ��� ����� ������ ����������
                clickCount = 0; // ���������� ������� ������ ��� ������
                ShowNextFact();
            }
        }
        else
        {
            ShowNextFact();
        }
    }

    void ShowNextFact()
    {
        clickCount++;
        if (clickCount > honeyFacts.Length)
        {
            clickCount = 1; // ������������� ���� ������
        }
        uiText.text = honeyFacts[clickCount - 1]; // ������� ���������� ����� ��� ��
    }

    void ClosePanel()
    {
        uiPanel.SetActive(false); // �������� ������
    }
}