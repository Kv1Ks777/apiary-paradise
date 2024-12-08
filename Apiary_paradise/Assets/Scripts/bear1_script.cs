using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bear1_script : MonoBehaviour
{
    public GameObject uiPanel; // Ссылка на UI панель
    public Text uiText; // Ссылка на UI текст
    public Button closeButton; // Ссылка на кнопку закрытия панели
    private int clickCount = 0; // Счетчик кликов
    private bool factsStarted = false; // Флаг для проверки начала вывода фактов

    private string[] messages = new string[]
    {
"Привет!",
"Должно быть ты тот самый медведь, который получил участок в подарок от родителей",
"Меня зовут Атай, я из традиции пасечников",
"Давай ты принесёшь мне 10 ячеек своего энергомёда и я скажу тебе какого он качества!",
"Пока недостаточно ячеек энергомёда",
"Ого",
"Даже на глаз вижу что это энергомёд отличного качества",
"Если что - обращайся"
    };

    private string[] honeyFacts = new string[]
    {
"Мед никогда не портится. В запечатанном виде он может храниться вечно",
"Пчелы должны посетить около 2 миллионов цветов, чтобы произвести 1 фунт меда",
"Мед использовался в медицине с древних времен благодаря своим антибактериальным свойствам",
"В среднем, одна пчела производит 1/12 чайной ложки меда за свою жизнь",
"Мед бывает разных вкусов и цветов в зависимости от источника нектара",
"Пчелы вырабатывают мед, чтобы пережить зиму, когда нет цветущих растений",
"Мед использовался в древнем Египте для бальзамирования тел",
"Мед содержит антиоксиданты, которые помогают бороться с воспалениями",
"Мед можно использовать как натуральное средство от кашля",
"Мед используется в косметике благодаря своим увлажняющим и антисептическим свойствам"
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
                int energomedCells = GlobalVariables.energy_honey_balance / 10;
                if (energomedCells < 10)
                {
                    uiText.text = messages[4]; // Пока недостаточно ячеек энергомёда
                    clickCount--; // Оставляем clickCount на этом уровне, чтобы повторно проверять количество ячеек
                }
                else
                {
                    GlobalVariables.energy_honey_balance -= 100; // Снимаем 10 ячеек энергомёда (100 единиц обычного энергомёда)
                    GlobalVariables.beekeeperRelations += 50; // Увеличиваем отношения с пасечниками
                    uiText.text = messages[5]; // Ого
                }
            }
            else if (clickCount == 6)
            {
                uiText.text = messages[6]; // Даже на глаз вижу что это энергомёд отличного качества
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
        if (clickCount > honeyFacts.Length)
        {
            clickCount = 1; // Перезапускаем цикл фактов
        }
        uiText.text = honeyFacts[clickCount - 1]; // Выводим интересные факты про мёд
    }

    void ClosePanel()
    {
        uiPanel.SetActive(false); // Скрываем панель
    }
}