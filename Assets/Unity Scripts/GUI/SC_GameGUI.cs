using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class SC_GameGUI : MonoBehaviour
{
    public bool Pause { get; set; }
    public AudioMixer amxMixer;
    public GameObject objGamePS;

    public void SetVolume(bool value)
    {
        if (!value) { amxMixer.SetFloat("volume", -80); }
        else if (value) { amxMixer.SetFloat("volume", 0); }
    }

    public void TryAgain()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void ReturnBack()
    {
        amxMixer.SetFloat("volume", 0);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    void Start() { Pause = true; }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape) || Input.GetKeyUp(KeyCode.Mouse1))
        {
            objGamePS.SetActive(Pause);
            Time.timeScale = Pause ? 0 : 1;
            Pause = !Pause;
        }
    }
}
