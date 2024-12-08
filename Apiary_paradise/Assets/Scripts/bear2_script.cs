using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class anatoly_script : MonoBehaviour
{
    public GameObject uiPanel; // Ссылка на UI панель
    public Text uiText; // Ссылка на UI текст
    public Button closeButton; // Ссылка на кнопку закрытия панели
    private int clickCount = 0; // Счетчик кликов
    private bool factsStarted = false; // Флаг для проверки начала вывода фактов

    private string[] messages = new string[]
    {
"Привет!",
"Ты, должно быть, тот самый медведь, который получил участок в подарок от родителей.",
"Меня зовут Анатолий, я из традиции Биоинженеры.",
"Принеси мне 10 цветов, и я расскажу тебе что-то интересное!",
"Пока недостаточно цветов.",
"Отлично!",
"Эти цветы просто великолепны!",
"Если что - обращайся."
    };

    private string[] bearFacts = new string[]
    {
"Медведи могут бегать со скоростью до 40 миль в час.",
"Полярные медведи могут прыгать на 2,4 метра из воды, чтобы поймать добычу.",
"Медведи обладают отличным обонянием, которое в 2,000 раз лучше, чем у людей.",
"Медведи могут жить до 30 лет в дикой природе.",
"Панды едят до 45 фунтов бамбука в день.",
"Медведи могут видеть в цвете.",
"Медведи умеют плавать на большие расстояния.",
"Медведи могут стоять и ходить на задних лапах.",
"Медведи обладают высоким уровнем интеллекта и могут запоминать места с едой до 10 лет.",
"Медведи имеют два слоя меха: один для тепла, другой для защиты от воды."
    };

    // Start is called before the first frame update
    void Start()
    {
        uiPanel.SetActive(false); // Скрываем панель при старте
        closeButton.onClick.AddListener(ClosePanel); // Добавляем обработчик нажатия на кнопку закрытия
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем нажатие на объект
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
        uiPanel.SetActive(true); // Показываем панель
        clickCount++;

        if (!factsStarted)
        {
            if (clickCount <= 4)
            {
                uiText.text = messages[clickCount - 1]; // Обновляем текст на панели
            }
            else if (clickCount == 5)
            {
                int flowerCount = GameData.flowers;
                if (flowerCount < 10)
                {
                    uiText.text = messages[4]; // Пока недостаточно цветов
                    clickCount--; // Оставляем clickCount на этом уровне, чтобы повторно проверять количество цветов
                }
                else
                {
                    GameData.flowers -= 10; // Снимаем 10 цветов
                    GameData.bioengineerRelations += 50; // Увеличиваем отношения с биоинженерами
                    uiText.text = messages[5]; // Отлично
                }
            }
            else if (clickCount == 6)
            {
                uiText.text = messages[6]; // Эти цветы просто великолепны
            }
            else if (clickCount == 7)
            {
                uiText.text = messages[7]; // Если что - обращайся
            }
            else if (clickCount >= 8)
            {
                factsStarted = true; // Устанавливаем флаг, что факты начали выводиться
                clickCount = 0; // Сбрасываем счетчик кликов для фактов
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
        if (clickCount > bearFacts.Length)
        {
            clickCount = 1; // Перезапускаем цикл фактов
        }
        uiText.text = bearFacts[clickCount - 1]; // Выводим интересные факты про медведей
    }

    void ClosePanel()
    {
        uiPanel.SetActive(false); // Скрываем панель
    }
}