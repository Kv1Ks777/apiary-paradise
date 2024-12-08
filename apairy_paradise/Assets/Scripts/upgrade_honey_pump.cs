using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgrade_honey_pump : MonoBehaviour
{
    public GameObject player; // ������ �� ������ player
    public GameObject targetObject1; // ������ �� ������ ������� ������
    public GameObject targetObject2; // ������ �� ������ ������� ������
    public Button upgradeButton; // ������ �� UI ������
    public Sprite[] upgradeSprites; // ������ �������� ��� ���������
    public int[] upgradeCosts; // ������ ��������� ���������
    public int[] energyIncreases; // ������ ���������� ������� ���� � ����
    public Text uiText; // UI Text, ������� ����� ���������� �������� ����������
    public AudioSource buttonAudioSource; // AudioSource ��� ����� ������
    public AudioSource upgradeAudioSource; // AudioSource ��� ����� ���������

    private int currentUpgradeLevel1 = 0; // ������� ������� ��������� ��� ������� �������
    private int currentUpgradeLevel2 = 0; // ������� ������� ��������� ��� ������� �������
    private GameObject currentTargetObject; // ������� ������� ������

    // Start is called before the first frame update
    void Start()
    {
        // ���������, ��� ������ ��������� � ������
        upgradeButton.gameObject.SetActive(false);
        // ��������� ���������� ������� ������
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        // ��������� ���������� ����� ������� � �������� ���������
        float distance1 = Vector3.Distance(player.transform.position, targetObject1.transform.position);
        float distance2 = Vector3.Distance(player.transform.position, targetObject2.transform.position);

        // ���������, ������������� �� ��������� �� ���� ���� ��� ������� ��������
        bool isFrozen1 = IsFrozen(targetObject1);
        bool isFrozen2 = IsFrozen(targetObject2);

        // ���� ����� ��������� � �������� 5 ������ �� ������ �� ������� �������� � ��������� �������������, ���������� ������
        if (distance1 < 5.0f && isFrozen1)
        {
            upgradeButton.gameObject.SetActive(true);
            currentTargetObject = targetObject1;
        }
        else if (distance2 < 5.0f && isFrozen2)
        {
            upgradeButton.gameObject.SetActive(true);
            currentTargetObject = targetObject2;
        }
        else
        {
            upgradeButton.gameObject.SetActive(false);
            currentTargetObject = null;
        }

        // ��������� ����� UI � �������� ���������� ���������� ����������
        // UpdateUIText();
    }

    void OnUpgradeButtonClick()
    {
        buttonAudioSource.Play(); // ����������� ���� ������

        if (currentTargetObject != null)
        {
            int currentUpgradeLevel = currentTargetObject == targetObject1 ? currentUpgradeLevel1 : currentUpgradeLevel2;

            // ���������, ����� �� ��� �������� ������
            if (currentUpgradeLevel < upgradeSprites.Length)
            {
                // ���������, ���������� �� ������� ���� ��� ���������
                if (GlobalVariables.energy_honey_balance >= upgradeCosts[currentUpgradeLevel])
                {
                    // ������ ������ � �������� �������
                    SpriteRenderer spriteRenderer = currentTargetObject.GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null)
                    {
                        spriteRenderer.sprite = upgradeSprites[currentUpgradeLevel];
                        Debug.Log("������ ������� �� ������� " + currentUpgradeLevel);
                    }
                    else
                    {
                        Debug.LogError("SpriteRenderer �� ������ �� ������� �������.");
                    }

                    // ����������� ������� ���� � ����
                    GlobalVariables.energy_honey_per_day += energyIncreases[currentUpgradeLevel];
                    // ��������� ������ ������� ����
                    GlobalVariables.energy_honey_balance -= upgradeCosts[currentUpgradeLevel];

                    // ��������� �� ��������� ������� ���������
                    if (currentTargetObject == targetObject1)
                    {
                        currentUpgradeLevel1++;
                    }
                    else
                    {
                        currentUpgradeLevel2++;
                    }

                    // ����������� ���� ���������
                    upgradeAudioSource.Play();

                    // ��������� ����� UI � �������� ���������� ���������� ����������
                    // UpdateUIText();
                }
                else
                {
                    Debug.Log("������������ ������� ���� ��� ���������.");
                }
            }
            else
            {
                Debug.Log("������������ ������� ��������� ���������.");
            }
        }
    }

    // void UpdateUIText()
    // {
    //     uiText.text = $"Energy Honey Balance: {GlobalVariables.energy_honey_balance}\nEnergy Honey per Day: {GlobalVariables.energy_honey_per_day}\nDays: {GlobalVariables.days}";
    // }

    bool IsFrozen(GameObject obj)
    {
        Rigidbody rb = obj.GetComponent<Rigidbody>();
        if (rb != null)
        {
            return rb.constraints == (RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ);
        }
        return false;
    }
}