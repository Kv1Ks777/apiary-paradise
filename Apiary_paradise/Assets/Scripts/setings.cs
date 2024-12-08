using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setings : MonoBehaviour
{
    public Button button1; // ������ ������
    public Button button2; // ������ ������
    public AudioSource button1AudioSource; // AudioSource ��� ������ ������
    public AudioSource button2AudioSource; // AudioSource ��� ������ ������
    public GameObject panel; // ������ � ������� �������� � ��������� ���������
    public Button closeButton; // ������ �������� ����
    public Slider volumeSlider; // �������� ��� ����������� ���������

    // Start is called before the first frame update
    void Start()
    {
        // ������������� ��������� ��������� ������ � ������
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);
        panel.SetActive(false);

        // ��������� ����������� ������� ������
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
        closeButton.onClick.AddListener(OnCloseButtonClick);
        volumeSlider.onValueChanged.AddListener(OnVolumeSliderChanged);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnButton1Click()
    {
        // ����������� ���� ��� ������ ������
        button1AudioSource.Play();

        // ������ ��������� ������
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);

        // ���������� ������
        panel.SetActive(true);
    }

    void OnButton2Click()
    {
        // ����������� ���� ��� ������ ������
        button2AudioSource.Play();

        // ������ ��������� ������
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

        // �������� ������
        panel.SetActive(false);
    }

    void OnCloseButtonClick()
    {
        // ��������� ����
        Application.Quit();
    }

    void OnVolumeSliderChanged(float value)
    {
        // ������������� ��������� ���� �����
        AudioListener.volume = value;
    }
}