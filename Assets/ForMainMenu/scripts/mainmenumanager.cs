using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenumanager : MonoBehaviour
{
    public GameObject oynabuton, ayarlarbuton, cıkısbuton, muzikackapa, sensayarı, turnMainMenu, muzikbut, sensbut, oyunismi, geriim;
    [SerializeField] private GameObject settingButton;
    public TextMeshProUGUI textMeshPro;
    public int sens, musicint;
    public Boolean music;

    private void Awake()
    {
        //mainbuttons
        oynabuton.SetActive(true);
        ayarlarbuton.SetActive(true);
        cıkısbuton.SetActive(true);
        oyunismi.SetActive(true);

        //ayarlarbutonları
        //muzikackapa.SetActive(false);
        //sensayarı.SetActive(false);
        turnMainMenu.SetActive(false);
        muzikbut.SetActive(false);
        sensbut.SetActive(false);
    }
    private void Update()
    {
       
        sens = (int)sensayarı.GetComponent<Slider>().value;
        textMeshPro.text = sens.ToString();
        PlayerPrefs.SetInt("sens", sens);
        music = muzikackapa.GetComponent<Toggle>().isOn;
        if (music)
        {
            musicint = 1;
            PlayerPrefs.SetInt("music", musicint);
        }
        if (!music)
        {
            musicint = 0;
            PlayerPrefs.SetInt("music", musicint);
        }
    }
    public void Startgame()
    {
        SceneManager.LoadSceneAsync("SampleScene");
    }
    public void SettingsMenu()
    {
        //mainbuttons
        oynabuton.SetActive(false);
        ayarlarbuton.SetActive(false);
        cıkısbuton.SetActive(false);
        oyunismi.SetActive(false);

        //ayarlarbutonları
        //muzikackapa.SetActive(true);
        //sensayarı.SetActive(true);
        turnMainMenu.SetActive(true);
        muzikbut.SetActive(true);
        sensbut.SetActive(true);
        settingButton.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void ayarlarmenukapat()
    {
        //mainbuttons
        oynabuton.SetActive(true);
        ayarlarbuton.SetActive(true);
        cıkısbuton.SetActive(true);
        oyunismi.SetActive(true);

        //ayarlarbutonları
        //muzikackapa.SetActive(false);
        //sensayarı.SetActive(false);
        turnMainMenu.SetActive(false);
        muzikbut.SetActive(false);
        sensbut.SetActive(false);
    }
}
