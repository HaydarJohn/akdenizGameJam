using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainmenumanager : MonoBehaviour
{
    public GameObject oynabuton, ayarlarbuton, exitButton, muzikackapa, sensayari, turnMainMenu, muzikbut, sensbut, oyunismi, geriim;
    [SerializeField] private GameObject settingButton;
    public TextMeshProUGUI textMeshPro;
    public int sens, musicint;
    public Boolean music;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSource hoverAudioSource;
    [SerializeField] private AudioClip hoverSound;

    private void Awake()
    {
        //mainbuttons
        oynabuton.SetActive(true);
        ayarlarbuton.SetActive(true);
        exitButton.SetActive(true);
        oyunismi.SetActive(true);
        

        //ayarlarbutonlar�
        //muzikackapa.SetActive(false);
        //sensayari.SetActive(false);
        turnMainMenu.SetActive(false);
        muzikbut.SetActive(false);
        sensbut.SetActive(false);
        // Add EventTriggers for buttons
        AddEventTrigger(oynabuton);
        AddEventTrigger(ayarlarbuton);
        AddEventTrigger(exitButton);
        AddEventTrigger(muzikbut);
        AddEventTrigger(sensbut);
        AddEventTrigger(turnMainMenu);
    }
    private void Start()
    {
        audioSource.Play();
    }
    private void Update()
    {

        sens = (int)sensayari.GetComponent<Slider>().value;
        textMeshPro.text = sens.ToString();
        PlayerPrefs.SetInt("sens", sens);
        music = muzikackapa.GetComponent<Toggle>().isOn;
        //if (music)
        //{
        //    audioSource.Play();
        //}
        //else
        //{
        //    audioSource.Stop();
        //}
        //if (music)
        //{
        //    musicint = 1;
        //    PlayerPrefs.SetInt("music", musicint);
        //}
        //if (!music)
        //{
        //    musicint = 0;
        //    PlayerPrefs.SetInt("music", musicint);
        //}
    }
    public void Startgame()
    {
        SceneManager.LoadScene(0);
    }
    public void SettingsMenu()
    {
        //mainbuttons
        oynabuton.SetActive(false);
        ayarlarbuton.SetActive(false);
        exitButton.SetActive(false);
        oyunismi.SetActive(false);

        //ayarlarbutonlar�
        //muzikackapa.SetActive(true);
        //sensayari.SetActive(true);
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
        exitButton.SetActive(true);
        oyunismi.SetActive(true);

        //ayarlarbutonlar�
        //muzikackapa.SetActive(false);
        //sensayari.SetActive(false);
        turnMainMenu.SetActive(false);
        muzikbut.SetActive(false);
        sensbut.SetActive(false);
    }

    private void AddEventTrigger(GameObject button)
    {
        EventTrigger trigger = button.AddComponent<EventTrigger>();

        // PointerEnter event
        EventTrigger.Entry pointerEnter = new EventTrigger.Entry();
        pointerEnter.eventID = EventTriggerType.PointerEnter;
        pointerEnter.callback.AddListener((data) => { OnPointerEnter(button); });
        trigger.triggers.Add(pointerEnter);

        // PointerExit event
        EventTrigger.Entry pointerExit = new EventTrigger.Entry();
        pointerExit.eventID = EventTriggerType.PointerExit;
        pointerExit.callback.AddListener((data) => { OnPointerExit(button); });
        trigger.triggers.Add(pointerExit);
    }

    private void OnPointerEnter(GameObject button)
    {
        Transform childTransform = button.transform.GetChild(0);
        if (childTransform != null)
        {
            Image image = childTransform.GetComponent<Image>();
            if (image != null)
            {
                Color color = image.color;
                color.a = 1f; // Set transparency to 50%
                image.color = color;
            }
        }
        hoverAudioSource.Play();
    }

    private void OnPointerExit(GameObject button)
    {
        Transform childTransform = button.transform.GetChild(0);
        if (childTransform != null)
        {
            Image image = childTransform.GetComponent<Image>();
            if (image != null)
            {
                Color color = image.color;
                color.a = 0f; // Reset transparency to 100%
                image.color = color;
            }
        }
    }

    //private void PlayHoverSound()
    //{
    //    if (hoverSound != null && audioSource != null)
    //    {
    //        audioSource.PlayOneShot(hoverSound);
    //    }
    //}
}
