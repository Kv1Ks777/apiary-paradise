using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class otnh : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public GameObject panel;
    public AudioClip sound1;
    public AudioClip sound2;
    private AudioSource audioSource;

    void Start()
    {
        button1.onClick.AddListener(OpenPanel);
        button2.onClick.AddListener(ClosePanel);
        button2.gameObject.SetActive(false);
        panel.SetActive(false);

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OpenPanel()
    {
        panel.SetActive(true);
        button1.gameObject.SetActive(false);
        button2.gameObject.SetActive(true);
        PlaySound(sound1);
    }

    void ClosePanel()
    {
        panel.SetActive(false);
        button2.gameObject.SetActive(false);
        button1.gameObject.SetActive(true);
        PlaySound(sound2);
    }

    void PlaySound(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
