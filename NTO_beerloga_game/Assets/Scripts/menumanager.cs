using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menumanager : MonoBehaviour
{
    public void ClickStart() 
    { 
        levelmeneger.PlayScene(Scenes.Game);
    }

    public void ClickExit() 
    { 
        Application.Quit(); 
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
