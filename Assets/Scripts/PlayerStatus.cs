using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{

    public float oxygenLevel;
    public static PlayerStatus Instance;
    [SerializeField] private GameObject gas;
    [SerializeField] private GameObject gasStation;
    private bool isGasStation;
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
        if (isGasStation == true) {
            oxygenLevel += Time.deltaTime * 2;

            if (oxygenLevel >= 10)
            {
                oxygenLevel = 10;
            }
        }
        if (oxygenLevel > 0 && isGasStation == false)
        {
            oxygenLevel -= Time.deltaTime / 2;
        }
        if (oxygenLevel <= 0)
        {
            GameSceneUIManager.Instance.GameOverText();
            GameManager.Instance.isGameOver = true;
        }
        Debug.Log(isGasStation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oxygen"))
        {
            oxygenLevel = 10;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("OxygenStation"))
        {
            isGasStation = true;
           
        }
    }
 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("OxygenStation"))
        {
            isGasStation = false;
        }
    }
}
