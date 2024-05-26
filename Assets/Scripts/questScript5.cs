using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questScript5 : MonoBehaviour
{
    private float progress = 0;
    public float progressSpeed = 25;
    private bool trigerred;
    // Start is called before the first frame update
    void Start()
    {
        trigerred = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(trigerred)
        {
            questManager.instance.incrementCompletion(progressSpeed*Time.deltaTime);
            progress = questManager.instance.getCompletion();
            progresBar();
        }
    }


    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            trigerred = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            trigerred = false;
        }
    }

    private void progresBar()
    {

    }
}
