using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    Main_menu,
    Game
}
public class levelmeneger : MonoBehaviour
{
    public levelmeneger Instance;
    void Start()
    {
        DontDestroyOnLoad(this);
        Instance = this;
        PlayScene(Scenes.Main_menu);
    }


    public static void PlayScene(Scenes sceneEnum)
    {
        SceneManager.LoadScene(sceneEnum.ToString());
    }
}