using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questManager : MonoBehaviour
{
    public static questManager instance;

    private const int MAX_QUESt_NUM = 6;
    private float completion;
    public int questCounter;
    public bool questChange;
    [SerializeField] GameObject quest1;
    [SerializeField] GameObject quest2;
    [SerializeField] GameObject quest3;
    [SerializeField] GameObject quest4;
    [SerializeField] GameObject quest5;
    [SerializeField] GameObject quest6;

    public bool quest1b = true,quest2b =false,quest3b =false,quest4b = false,quest5b = false,quest6b = false;


    // Start is called before the first frame update

    private void Awake()
    {
        if(instance == null)
        {
            instance =this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        completion = 0;
        questCounter = 0;
       
    }

    // Update is called once per frame
    void Update()
    {
        if(quest1b)
        {
            quest1.GetComponent<BoxColider2D>().enable = true;
        }
        else
        {
            quest1.GetComponent<BoxColider2D>().enable = false;
        }
        if(quest2b)
        {
            quest2.GetComponent<BoxColider2D>().enable = true;

        }
        else
        {
            quest2.GetComponent<BoxColider2D>().enable = false;

        }
        if(quest3b)
        {
            quest3.GetComponent<BoxColider2D>().enable = true;

        }
        else
        {
            
            quest3.GetComponent<BoxColider2D>().enable = false;
        }
        if(quest4b)
        {
            quest4.GetComponent<BoxColider2D>().enable = true;

        }
        else
        {
            quest4.GetComponent<BoxColider2D>().enable = false;

        }
        if(quest5b)
        {
            quest5.GetComponent<BoxColider2D>().enable = true;

        }
        else
        {
            quest5.GetComponent<BoxColider2D>().enable = false;
            
        }
        if(quest6b)
        {
            quest6.GetComponent<BoxColider2D>().enable = true;

        }
        else
        {
            quest6.GetComponent<BoxColider2D>().enable = false;

        }
    }

    public void incrementCompletion(float completion)
    {
        //Debug.Log(this.completion);
        this.completion += completion;
        if(this.completion > 100)
        {
            this.completion = 0;
            questCounter++;
            questChange = true;
        }
    }

    public float getCompletion()
    {
        return this.completion;
    }
    
    private void loadQuest()
    {


        // prev = current;
        // current = quests[questCounter];
        // if(questCounter < MAX_QUESt_NUM)
        // {
        //     Destroy(prev);
        //     Instantiate(current);
        // }
        // else
        // {
        //     // TODO call win func in gameManager
        //     Debug.Log("NIGGERRRRRR");
        // }


    }
}
