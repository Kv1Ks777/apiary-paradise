using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class perehod : MonoBehaviour
{
    public GameObject object1;
    public GameObject object2;
    public Transform player;

    void Start()
    {
        if (object1 == null || object2 == null || player == null)
        {
            Debug.LogError("One or more references are not assigned in the Inspector.");
            return;
        }

        // Ensure the objects have 2D colliders and are set to trigger
        if (object1.GetComponent<Collider2D>() == null)
            object1.AddComponent<BoxCollider2D>().isTrigger = true;
        if (object2.GetComponent<Collider2D>() == null)
            object2.AddComponent<BoxCollider2D>().isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger entered by: " + other.gameObject.name);

        if (other.gameObject == object1)
        {
            Debug.Log("Teleporting to first location");
            player.position = new Vector3(235.12f, -11.42f, player.position.z);
        }
        else if (other.gameObject == object2)
        {
            Debug.Log("Teleporting to second location");
            player.position = new Vector3(34.49f, -0.45f, player.position.z);
        }
    }
}