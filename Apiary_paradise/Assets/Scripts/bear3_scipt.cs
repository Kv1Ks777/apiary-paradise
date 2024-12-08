using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bear3_script : MonoBehaviour
{
    public GameObject uiPanel; // Ссылка на UI панель
    public Text uiText; // Ссылка на UI текст
    public Button closeButton; // Ссылка на кнопку закрытия панели
    private int clickCount = 0; // Счетчик кликов
    private bool friendshipAchieved = false; // Флаг для проверки достижения дружбы

    private string[] messages = new string[]
    {
"Привет!",
"Ты, должно быть, тот самый медведь, который получил участок в подарок от родителей.",
"Меня зовут Павлик, я из традиции программистов.",
"Чтобы подружиться со мной, тебе нужно иметь общее отношение с двумя другими медведями на уровне 1000.",
"Пока недостаточно общего отношения.",
"Отлично! Теперь мы друзья!",
"Если что - обращайся."
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

        if (!friendshipAchieved)
        {
            if (clickCount <= 3)
            {
                uiText.text = messages[clickCount - 1]; // Обновляем текст на панели
            }
            else if (clickCount == 4)
            {
                int totalRelations = GameData.bioengineerRelations + GameData.otherBear1Relations + GameData.otherBear2Relations; // Учитываем отношения с двумя другими медведями
                if (totalRelations <= 100)
                {
                    uiText.text = messages[4]; // Пока недостаточно общего отношения
                    clickCount--; // Оставляем clickCount на этом уровне, чтобы повторно проверять общее отношение
                }
                else
                {
                    friendshipAchieved = true; // Устанавливаем флаг, что дружба достигнута
                    uiText.text = messages[5]; // Отлично! Теперь мы друзья!
                }
            }
            else if (clickCount == 5)
            {
                uiText.text = messages[6]; // Если что - обращайся
            }
        }
        else
        {
            uiText.text = messages[6]; // Если что - обращайся
        }
    }

    void ClosePanel()
    {
        uiPanel.SetActive(false); // Скрываем панель
    }
}