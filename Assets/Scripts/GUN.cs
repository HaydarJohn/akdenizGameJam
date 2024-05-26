 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject FiredGun;
    [SerializeField] private GameObject EnemyObj;

    private Rigidbody2D rb;


    void Awake()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(rb.position, mousePosition, 50);
            if(hit.collider.GetComponent<GameObject>() == EnemyObj)
            {
                EnemyObj.GetComponent<Enemy>().SlowDown();
            }
        }
    }
}
