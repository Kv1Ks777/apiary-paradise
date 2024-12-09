using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StroikaButton : MonoBehaviour
{
    public Button button1; // ������ ������
    public Button button2; // ������ ������
    public List<GameObject> prefabs; // ������ �������� ��� ������
    public AudioSource audioSource; // AudioSource ��� ������������ �����
    private GameObject currentPrefabInstance; // ������� ��������� �������
    private bool isPlacingPrefab = false; // ���� ��� ������������ ��������� ���������� �������
    private int selectedPrefabIndex = 0; // ������ ���������� �������

    // Start is called before the first frame update
    void Start()
    {
        // ������������� ��������� ��������� ������
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

        // ��������� ����������� ������� ������
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingPrefab && currentPrefabInstance != null)
        {
            // ������� �� ��������
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f; // ������������� z-������� ��� ������
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPrefabInstance.transform.position = worldPosition;

            // ��������� ������� ������� "P"
            if (Input.GetKeyDown(KeyCode.P))
            {
                // ��������� ������ �� �����
                isPlacingPrefab = false;
                // ��������� ������ ������� ����
                GlobalVariables.energy_honey_balance -= 200;
                // ������� ����� ��������� ������� ��� ���������� ����������
                currentPrefabInstance = Instantiate(prefabs[selectedPrefabIndex]);
                isPlacingPrefab = true;
            }
        }
    }

    void OnButton1Click()
    {
        // ����������� ����
        audioSource.Play();

        // ������ ��������� ������
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);

        // ������� ��������� ���������� ������� � �������� ��� ����������
        currentPrefabInstance = Instantiate(prefabs[selectedPrefabIndex]);
        isPlacingPrefab = true;
    }

    void OnButton2Click()
    {
        // ����������� ����
        audioSource.Play();

        // ������ ��������� ������
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

        // ������� ������� ������, ���� �� ����������
        if (currentPrefabInstance != null)
        {
            Destroy(currentPrefabInstance);
            currentPrefabInstance = null;
            isPlacingPrefab = false;
        }
    }

    // ����� ��� ������ �������
    public void SelectPrefab(int index)
    {
        if (index >= 0 && index < prefabs.Count)
        {
            selectedPrefabIndex = index;
        }
    }
}

public class PrefabBuilder : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Instantiate(prefab1, Vector3.zero, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Instantiate(prefab2, Vector3.zero, Quaternion.identity);
        }
    }
}