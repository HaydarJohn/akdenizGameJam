// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;
// public class MonolougeScript : MonoBehaviour
// {
//     //public TextMeshProGUI;

//     public string[] lines;
//     public float textSpeed;

//     private int index;

//     // Start is called before the first frame update
//     void Start()
//     {
//         //this.GetComponent<TextMeshProGUI>().text = string.Empty;
//         StartMonolouge();
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }

//     void StartMonolouge()
//     {
//         index = 0;
//         StartCoroutine(TypeLine());
//     }

//     IEnumerator TypeLine()
//     {
//         foreach (char c in lines[index].ToCharArray())
//         {
//             text += c;
//             yield return new WaitForSeconds(textSpeed);
//         }
//     }
// }
