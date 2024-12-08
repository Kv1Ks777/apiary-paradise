using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tourel : MonoBehaviour
{
    public float rotationSpeed = 30.0f; // Скорость вращения в градусах в секунду

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Вращаем объект по оси Z
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }
}