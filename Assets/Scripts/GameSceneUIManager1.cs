// using System.Collections;
// using System.Collections.Generic;
// using TMPro;
// using UnityEngine;

// public class GameSceneUIManager : MonoBehaviour
// {
//     [SerializeField] private TextMeshProUGUI gameOverText;
//     [SerializeField] private TextMeshProUGUI gameWinText;
//     public static GameSceneUIManager Instance;
//     private void Awake()
//     {
//         if (Instance == null)
//         {
//             Instance = this;
//         }
//         else
//         {
//             Destroy(this.gameObject);
//         }
//     }
//     public void GameOverText()
//     {
//         gameOverText.gameObject.SetActive(true);
//     } public void GameWin()
//     {
//         gameOverText.gameObject.SetActive(true);
//     }
// }
