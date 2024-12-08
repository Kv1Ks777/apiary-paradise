using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class osi : MonoBehaviour
{
    public GameObject prefab; // Префаб, который будет создаваться

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Start method called");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Update method called. Days: " + GlobalVariables.days);

        if (GlobalVariables.days % 5 == 0 && GlobalVariables.days != 0)
        {
            Debug.Log("Creating prefabs");
            for (int i = 0; i < 5; i++)
            {
                Instantiate(prefab, new Vector3(i * 2.0F, 0, 0), Quaternion.identity);
            }
            GlobalVariables.days++; // Увеличиваем дни, чтобы избежать повторного создания префабов в следующем кадре
        }
    }
}