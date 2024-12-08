using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalVariables
{
    public static int energy_honey_balance = 300; // ���������� ���������� ������� ������� ����
    public static int energy_honey_per_day = 100; // ���������� ���������� ������� ���� � ����
    public static int days = 0; // ���������� ���������� ����
    public static int beekeeperRelations = 0; // ��������� � �����������
}

public class day_skip : MonoBehaviour
{
    public GameObject player; // ������ ������
    public GameObject targetObject; // ������, � ������� ����� �����������������
    public Button uiButton; // UI ������, ������� ����� ���������� � ��������
    public Image uiImage; // UI Image, ������� ����� �������������
    public Text uiText; // UI Text, ������� ����� ���������� �������� ����������
    public AudioSource buttonAudioSource; // AudioSource ��� ����� ������
    public AudioSource animationAudioSource; // AudioSource ��� ����� ��������

    private Vector3 initialImagePosition; // �������� ������� UI Image
    private bool isAnimating = false; // ���� ��� ������������ ��������� ��������
                                      // private float dayDuration = 90.0f; // ������������ ��� � �������� (1.5 ������)
                                      // private float remainingTime; // ���������� ����� �� ����� ���

    // Start is called before the first frame update
    void Start()
    {
        uiButton.gameObject.SetActive(false); // �������� ������ ��� ������
        initialImagePosition = uiImage.rectTransform.localPosition; // ��������� �������� ������� UI Image
        uiButton.onClick.AddListener(OnButtonClick); // ��������� ���������� ������� ������
                                                     // remainingTime = dayDuration; // ������������� ��������� �������� ����������� �������
                                                     // StartCoroutine(AutoEndDay()); // ��������� �������� ��� ��������������� ���������� ���
    }

    // Update is called once per frame
    void Update()
    {
        // ��������� ���������� ����� ������� � ������� ��������
        float distance = Vector3.Distance(player.transform.position, targetObject.transform.position);

        // ���� ����� ��������� � �������� 4 ������ �� �������� �������, ���������� ������
        if (distance < 4.0f)
        {
            uiButton.gameObject.SetActive(true);
        }
        else
        {
            uiButton.gameObject.SetActive(false);
        }

        // ��������� ����� UI � �������� ���������� ���������� ����������
        uiText.text = $"�������������� �� � �������: {GlobalVariables.energy_honey_balance}\n" +
        $"������ ��������������� ��� � ����: {GlobalVariables.energy_honey_per_day}\n" +
        $"����: {GlobalVariables.days}";
    }

    void OnButtonClick()
    {
        buttonAudioSource.Play(); // ����������� ���� ������
        if (!isAnimating)
        {
            StartCoroutine(AnimateImage());
        }
    }

    IEnumerator AnimateImage()
    {
        isAnimating = true; // ������������� ���� ��������
        animationAudioSource.Play(); // ����������� ���� ��������
        float duration = 3.0f; // ������������ ��������
        Vector3 targetPosition = new Vector3(initialImagePosition.x, initialImagePosition.y - 5000, initialImagePosition.z); // ������� �������

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            uiImage.rectTransform.localPosition = Vector3.Lerp(initialImagePosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiImage.rectTransform.localPosition = targetPosition; // ��������, ��� ������� ����� �����������
        GlobalVariables.days++; // ����������� ���������� ���������� ����
        GlobalVariables.energy_honey_balance += GlobalVariables.energy_honey_per_day; // ����������� ������ ������� ����

        // ��������� ����� UI � �������� ���������� ���������� ����������
        uiText.text = $"�������������� �� � �������: {GlobalVariables.energy_honey_balance}\n" +
        $"������ ��������������� ��� � ����: {GlobalVariables.energy_honey_per_day}\n" +
        $"����: {GlobalVariables.days}";

        // ���������� UI Image � �������� �������
        uiImage.rectTransform.localPosition = initialImagePosition;
        isAnimating = false; // ���������� ���� ��������
                             // remainingTime = dayDuration; // ���������� ���������� ����� ��� ������ ���
                             // StartCoroutine(AutoEndDay()); // ��������� �������� ��� ������ ���
    }

    // IEnumerator AutoEndDay()
    // {
    //     while (remainingTime > 0)
    //     {
    //         yield return null; // ���� ���� ����
    //     }

    //     if (!isAnimating)
    //     {
    //         StartCoroutine(AnimateImage()); // ��������� ��������, ���� ��� ��� �� ��������
    //     }
    // }
}