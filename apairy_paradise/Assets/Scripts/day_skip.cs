using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class GlobalVariables
{
    public static int energy_honey_balance = 300; // Глобальная переменная баланса энергии меда
    public static int energy_honey_per_day = 100; // Глобальная переменная энергии меда в день
    public static int days = 0; // Глобальная переменная дней
    public static int beekeeperRelations = 0; // Отношения с пасечниками
}

public class day_skip : MonoBehaviour
{
    public GameObject player; // Объект игрока
    public GameObject targetObject; // Объект, с которым нужно взаимодействовать
    public Button uiButton; // UI кнопка, которая будет появляться и исчезать
    public Image uiImage; // UI Image, который будет анимироваться
    public Text uiText; // UI Text, который будет отображать значения переменных
    public AudioSource buttonAudioSource; // AudioSource для звука кнопки
    public AudioSource animationAudioSource; // AudioSource для звука анимации

    private Vector3 initialImagePosition; // Исходная позиция UI Image
    private bool isAnimating = false; // Флаг для отслеживания состояния анимации
                                      // private float dayDuration = 90.0f; // Длительность дня в секундах (1.5 минуты)
                                      // private float remainingTime; // Оставшееся время до конца дня

    // Start is called before the first frame update
    void Start()
    {
        uiButton.gameObject.SetActive(false); // Скрываем кнопку при старте
        initialImagePosition = uiImage.rectTransform.localPosition; // Сохраняем исходную позицию UI Image
        uiButton.onClick.AddListener(OnButtonClick); // Добавляем обработчик нажатия кнопки
                                                     // remainingTime = dayDuration; // Устанавливаем начальное значение оставшегося времени
                                                     // StartCoroutine(AutoEndDay()); // Запускаем корутину для автоматического завершения дня
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем расстояние между игроком и целевым объектом
        float distance = Vector3.Distance(player.transform.position, targetObject.transform.position);

        // Если игрок находится в пределах 4 единиц от целевого объекта, показываем кнопку
        if (distance < 4.0f)
        {
            uiButton.gameObject.SetActive(true);
        }
        else
        {
            uiButton.gameObject.SetActive(false);
        }

        // Обновляем текст UI с текущими значениями глобальных переменных
        uiText.text = $"энергетический мёд в наличии: {GlobalVariables.energy_honey_balance}\n" +
        $"добыча энергетического мёда в день: {GlobalVariables.energy_honey_per_day}\n" +
        $"день: {GlobalVariables.days}";
    }

    void OnButtonClick()
    {
        buttonAudioSource.Play(); // Проигрываем звук кнопки
        if (!isAnimating)
        {
            StartCoroutine(AnimateImage());
        }
    }

    IEnumerator AnimateImage()
    {
        isAnimating = true; // Устанавливаем флаг анимации
        animationAudioSource.Play(); // Проигрываем звук анимации
        float duration = 3.0f; // Длительность анимации
        Vector3 targetPosition = new Vector3(initialImagePosition.x, initialImagePosition.y - 5000, initialImagePosition.z); // Целевая позиция

        float elapsedTime = 0;

        while (elapsedTime < duration)
        {
            uiImage.rectTransform.localPosition = Vector3.Lerp(initialImagePosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        uiImage.rectTransform.localPosition = targetPosition; // Убедимся, что позиция точно установлена
        GlobalVariables.days++; // Увеличиваем глобальную переменную дней
        GlobalVariables.energy_honey_balance += GlobalVariables.energy_honey_per_day; // Увеличиваем баланс энергии меда

        // Обновляем текст UI с текущими значениями глобальных переменных
        uiText.text = $"энергетический мёд в наличии: {GlobalVariables.energy_honey_balance}\n" +
        $"добыча энергетического мёда в день: {GlobalVariables.energy_honey_per_day}\n" +
        $"день: {GlobalVariables.days}";

        // Возвращаем UI Image в исходную позицию
        uiImage.rectTransform.localPosition = initialImagePosition;
        isAnimating = false; // Сбрасываем флаг анимации
                             // remainingTime = dayDuration; // Сбрасываем оставшееся время для нового дня
                             // StartCoroutine(AutoEndDay()); // Запускаем корутину для нового дня
    }

    // IEnumerator AutoEndDay()
    // {
    //     while (remainingTime > 0)
    //     {
    //         yield return null; // Ждем один кадр
    //     }

    //     if (!isAnimating)
    //     {
    //         StartCoroutine(AnimateImage()); // Запускаем анимацию, если она еще не запущена
    //     }
    // }
}