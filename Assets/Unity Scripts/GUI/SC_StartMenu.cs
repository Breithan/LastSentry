using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;

public class SC_StartMenu : MonoBehaviour
{
    public AudioClip clickClip;
    public AudioClip clickReturn;
    public AudioClip quitClip;
    public AudioMixer admAudio;

    public void newScene()
    {
        this.GetComponent<AudioSource>().clip = clickClip;
        this.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        GetComponent<AudioSource>().clip = quitClip;
        GetComponent<AudioSource>().Play();
        Application.Quit();
    }

    public void openList()
    {
        this.GetComponent<AudioSource>().clip = clickClip;
        this.GetComponent<AudioSource>().Play();
    }

    public void quitList()
    {
        this.GetComponent<AudioSource>().clip = clickReturn;
        this.GetComponent<AudioSource>().Play();
    }

    public void HardShip(float value)
    {
        PlayerPrefs.SetFloat("Hardship", value);
    }

    public void GameMode(float value)
    {
        PlayerPrefs.SetFloat("Gamemode", value);
    }

    private void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetFloat("Hardship", 1);
        PlayerPrefs.SetFloat("Gamemode", 1);
    }

    public void OpenPanel(GameObject panel)
    {
        if (panel.activeSelf != true)
        {
            panel.SetActive(true);
            panel.AddComponent<SC_PanelAnim>();
            panel.GetComponent<SC_PanelAnim>().Open = true;
        }
    }

    public void ClosePanel(GameObject panel)
    {
        panel.AddComponent<SC_PanelAnim>();
        panel.GetComponent<SC_PanelAnim>().Open = false;
    }
}
