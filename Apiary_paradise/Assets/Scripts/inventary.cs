using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class inventary : MonoBehaviour
{
    public Text energomedText; // —сылка на UI текст дл€ €чеек энергомЄда
    public Text flowersText; // —сылка на UI текст дл€ цветов
    public Text woodText; // —сылка на UI текст дл€ дерева

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI(); // ќбновл€ем UI при старте
    }

    // Update is called once per frame
    void Update()
    {
        UpdateUI(); // ќбновл€ем UI каждый кадр
    }

    void UpdateUI()
    {
        // –ассчитываем количество €чеек энергомЄда
        int energomedCells = GlobalVariables.energy_honey_balance / 10;

        energomedText.text = energomedCells.ToString();
        flowersText.text = GameData.flowers.ToString();
        woodText.text = GameData.wood.ToString();
    }
}