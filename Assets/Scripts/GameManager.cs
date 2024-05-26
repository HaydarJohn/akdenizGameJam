using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    float sayac;
    public bool isGameOver = false;
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
    private void Update()
    {
        sayac += Time.deltaTime;
        if (sayac >= 4)
        {
            SoundManager.Instance.monsterLoopSes.Play();
        }
    }
    public void Win()
    {
        Debug.Log("You win!");
        GameSceneUIManager.Instance.GameWin();
    }
    public void Lose()
    {
        if (isGameOver == true)
        {
            SoundManager.Instance.finishOxygen.clip = SoundManager.Instance.finishOxygenClip;
            SoundManager.Instance.finishOxygen.Play();
        }
    }
}
