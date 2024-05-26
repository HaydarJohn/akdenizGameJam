using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField] const float MAX_SPEED = 4;
    public Transform target;

    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
        SpeedManager();
    }

    public void SlowDown()
    {
        agent.speed -= 0.5f;
    }

    private void SpeedManager()
    {
        if(agent.speed < 0)
        {
            agent.speed = 0;
            float timer = 0;
            while(timer < 2.5f)
            {
                timer += 1 * Time.deltaTime;
            }
        }
        agent.speed += 1 * Time.deltaTime;
        if(agent.speed > MAX_SPEED)
        {
            agent.speed = MAX_SPEED;
        }
    }
}
