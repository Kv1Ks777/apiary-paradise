using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class upgrade_honey_pump : MonoBehaviour
{
    public GameObject player; // Ссылка на объект player
    public GameObject targetObject1; // Ссылка на первый целевой объект
    public GameObject targetObject2; // Ссылка на второй целевой объект
    public Button upgradeButton; // Ссылка на UI кнопку
    public Sprite[] upgradeSprites; // Массив спрайтов для улучшений
    public int[] upgradeCosts; // Массив стоимости улучшений
    public int[] energyIncreases; // Массив увеличения энергии меда в день
    public Text uiText; // UI Text, который будет отображать значения переменных
    public AudioSource buttonAudioSource; // AudioSource для звука кнопки
    public AudioSource upgradeAudioSource; // AudioSource для звука улучшения

    private int currentUpgradeLevel1 = 0; // Текущий уровень улучшения для первого объекта
    private int currentUpgradeLevel2 = 0; // Текущий уровень улучшения для второго объекта
    private GameObject currentTargetObject; // Текущий целевой объект

    // Start is called before the first frame update
    void Start()
    {
        // Убедитесь, что кнопка неактивна в начале
        upgradeButton.gameObject.SetActive(false);
        // Добавляем обработчик нажатия кнопки
        upgradeButton.onClick.AddListener(OnUpgradeButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем расстояние между игроком и целевыми объектами
        float distance1 = Vector3.Distance(player.transform.position, targetObject1.transform.position);
        float distance2 = Vector3.Distance(player.transform.position, targetObject2.transform.position);

        // Проверяем, зафиксированы ли заморозки по всем осям для целевых объектов
        bool isFrozen1 = IsFrozen(targetObject1);
        bool isFrozen2 = IsFrozen(targetObject2);

        // Если игрок находится в пределах 5 единиц от одного из целевых объектов и заморозка зафиксирована, показываем кнопку
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

        // Обновляем текст UI с текущими значениями глобальных переменных
        // UpdateUIText();
    }

    void OnUpgradeButtonClick()
    {
        buttonAudioSource.Play(); // Проигрываем звук кнопки

        if (currentTargetObject != null)
        {
            int currentUpgradeLevel = currentTargetObject == targetObject1 ? currentUpgradeLevel1 : currentUpgradeLevel2;

            // Проверяем, можно ли еще улучшать объект
            if (currentUpgradeLevel < upgradeSprites.Length)
            {
                // Проверяем, достаточно ли энергии меда для улучшения
                if (GlobalVariables.energy_honey_balance >= upgradeCosts[currentUpgradeLevel])
                {
                    // Меняем спрайт у целевого объекта
                    SpriteRenderer spriteRenderer = currentTargetObject.GetComponent<SpriteRenderer>();
                    if (spriteRenderer != null)
                    {
                        spriteRenderer.sprite = upgradeSprites[currentUpgradeLevel];
                        Debug.Log("Спрайт изменен на уровень " + currentUpgradeLevel);
                    }
                    else
                    {
                        Debug.LogError("SpriteRenderer не найден на целевом объекте.");
                    }

                    // Увеличиваем энергию меда в день
                    GlobalVariables.energy_honey_per_day += energyIncreases[currentUpgradeLevel];
                    // Уменьшаем баланс энергии меда
                    GlobalVariables.energy_honey_balance -= upgradeCosts[currentUpgradeLevel];

                    // Переходим на следующий уровень улучшения
                    if (currentTargetObject == targetObject1)
                    {
                        currentUpgradeLevel1++;
                    }
                    else
                    {
                        currentUpgradeLevel2++;
                    }

                    // Проигрываем звук улучшения
                    upgradeAudioSource.Play();

                    // Обновляем текст UI с текущими значениями глобальных переменных
                    // UpdateUIText();
                }
                else
                {
                    Debug.Log("Недостаточно энергии меда для улучшения.");
                }
            }
            else
            {
                Debug.Log("Максимальный уровень улучшения достигнут.");
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