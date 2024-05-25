using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;
    [SerializeField] private GameObject player;

    private void Start()
    {
        totalHealthBar.fillAmount = PlayerStatus.Instance.oxygenLevel / 10;
    }

    private void Update()
    {
        totalHealthBar.fillAmount = PlayerStatus.Instance.oxygenLevel / 10;
    }
}
