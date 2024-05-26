using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;
    public AudioSource monsterLoopSes;
    public AudioSource monsterKovalama;
    public AudioSource finishOxygen;
    public AudioClip finishOxygenClip;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
          
        }
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

}
