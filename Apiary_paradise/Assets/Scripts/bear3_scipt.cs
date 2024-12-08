using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bear3_script : MonoBehaviour
{
    public GameObject uiPanel; // ������ �� UI ������
    public Text uiText; // ������ �� UI �����
    public Button closeButton; // ������ �� ������ �������� ������
    private int clickCount = 0; // ������� ������
    private bool friendshipAchieved = false; // ���� ��� �������� ���������� ������

    private string[] messages = new string[]
    {
"������!",
"��, ������ ����, ��� ����� �������, ������� ������� ������� � ������� �� ���������.",
"���� ����� ������, � �� �������� �������������.",
"����� ����������� �� ����, ���� ����� ����� ����� ��������� � ����� ������� ��������� �� ������ 1000.",
"���� ������������ ������ ���������.",
"�������! ������ �� ������!",
"���� ��� - ���������."
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

        if (!friendshipAchieved)
        {
            if (clickCount <= 3)
            {
                uiText.text = messages[clickCount - 1]; // ��������� ����� �� ������
            }
            else if (clickCount == 4)
            {
                int totalRelations = GameData.bioengineerRelations + GameData.otherBear1Relations + GameData.otherBear2Relations; // ��������� ��������� � ����� ������� ���������
                if (totalRelations <= 100)
                {
                    uiText.text = messages[4]; // ���� ������������ ������ ���������
                    clickCount--; // ��������� clickCount �� ���� ������, ����� �������� ��������� ����� ���������
                }
                else
                {
                    friendshipAchieved = true; // ������������� ����, ��� ������ ����������
                    uiText.text = messages[5]; // �������! ������ �� ������!
                }
            }
            else if (clickCount == 5)
            {
                uiText.text = messages[6]; // ���� ��� - ���������
            }
        }
        else
        {
            uiText.text = messages[6]; // ���� ��� - ���������
        }
    }

    void ClosePanel()
    {
        uiPanel.SetActive(false); // �������� ������
    }
}