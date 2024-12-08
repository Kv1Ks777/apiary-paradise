using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setings : MonoBehaviour
{
    public Button button1; // Первая кнопка
    public Button button2; // Вторая кнопка
    public AudioSource button1AudioSource; // AudioSource для первой кнопки
    public AudioSource button2AudioSource; // AudioSource для второй кнопки
    public GameObject panel; // Панель с кнопкой закрытия и ползунком громкости
    public Button closeButton; // Кнопка закрытия игры
    public Slider volumeSlider; // Ползунок для регулировки громкости

    // Start is called before the first frame update
    void Start()
    {
        // Устанавливаем начальное состояние кнопок и панели
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);
        panel.SetActive(false);

        // Добавляем обработчики нажатия кнопок
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
        // Проигрываем звук для первой кнопки
        button1AudioSource.Play();

        // Меняем состояние кнопок
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);

        // Показываем панель
        panel.SetActive(true);
    }

    void OnButton2Click()
    {
        // Проигрываем звук для второй кнопки
        button2AudioSource.Play();

        // Меняем состояние кнопок
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

        // Скрываем панель
        panel.SetActive(false);
    }

    void OnCloseButtonClick()
    {
        // Закрываем игру
        Application.Quit();
    }

    void OnVolumeSliderChanged(float value)
    {
        // Устанавливаем громкость всей сцены
        AudioListener.volume = value;
    }
}