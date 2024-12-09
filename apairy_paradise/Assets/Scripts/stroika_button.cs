using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StroikaButton : MonoBehaviour
{
    public Button button1; // Первая кнопка
    public Button button2; // Вторая кнопка
    public List<GameObject> prefabs; // Список префабов для выбора
    public AudioSource audioSource; // AudioSource для проигрывания звука
    private GameObject currentPrefabInstance; // Текущий экземпляр префаба
    private bool isPlacingPrefab = false; // Флаг для отслеживания состояния размещения префаба
    private int selectedPrefabIndex = 0; // Индекс выбранного префаба

    // Start is called before the first frame update
    void Start()
    {
        // Устанавливаем начальное состояние кнопок
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

        // Добавляем обработчики нажатия кнопок
        button1.onClick.AddListener(OnButton1Click);
        button2.onClick.AddListener(OnButton2Click);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlacingPrefab && currentPrefabInstance != null)
        {
            // Следуем за курсором
            Vector3 mousePosition = Input.mousePosition;
            mousePosition.z = 10.0f; // Устанавливаем z-позицию для камеры
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            currentPrefabInstance.transform.position = worldPosition;

            // Проверяем нажатие клавиши "P"
            if (Input.GetKeyDown(KeyCode.P))
            {
                // Фиксируем префаб на месте
                isPlacingPrefab = false;
                // Уменьшаем баланс энергии меда
                GlobalVariables.energy_honey_balance -= 200;
                // Создаем новый экземпляр префаба для следующего размещения
                currentPrefabInstance = Instantiate(prefabs[selectedPrefabIndex]);
                isPlacingPrefab = true;
            }
        }
    }

    void OnButton1Click()
    {
        // Проигрываем звук
        audioSource.Play();

        // Меняем состояние кнопок
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);

        // Создаем экземпляр выбранного префаба и начинаем его размещение
        currentPrefabInstance = Instantiate(prefabs[selectedPrefabIndex]);
        isPlacingPrefab = true;
    }

    void OnButton2Click()
    {
        // Проигрываем звук
        audioSource.Play();

        // Меняем состояние кнопок
        button1.gameObject.SetActive(true);
        button2.gameObject.SetActive(false);

        // Удаляем текущий префаб, если он существует
        if (currentPrefabInstance != null)
        {
            Destroy(currentPrefabInstance);
            currentPrefabInstance = null;
            isPlacingPrefab = false;
        }
    }

    // Метод для выбора префаба
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