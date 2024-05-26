using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ProgresBarScript : MonoBehaviour
{
    [SerializeField] GameObject bottomBar;
    // Start is called before the first frame update
    void Start()
    {
        bottomBar.GetComponent<Image>().enabled = true;
        GetComponent<Image>().enabled = true;
        transform.localScale = new Vector3(0, transform.localScale.y , transform.localScale.z);;

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x + Time.deltaTime * 0.1f , transform.localScale.y , transform.localScale.z);
        //Time.deltaTime * 0.1f;
    }
}
