using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class questManager : MonoBehaviour
{
    public static questManager instance;

    private const int MAX_QUESt_NUM = 1;
    private float completion;
    public int questCounter;
    public bool questChange;
    [SerializeField] GameObject[] quests;
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
        questChange = false;
        Instantiate(quests[0]);
    }

    // Update is called once per frame
    void Update()
    {
        if(questChange)
        {
            questChange = false;
            loadQuest();
        }
    }

    public void incrementCompletion(float completion)
    {
        Debug.Log(this.completion);
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
        if(questCounter < MAX_QUESt_NUM)
        {
            Destroy(quests[questCounter - 1]);
            Instantiate(quests[questCounter]);
        }
        else
        {
            // TODO call win func in gameManager
            Debug.Log("NIGGERRRRRR");
        }

    }
}
