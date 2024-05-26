using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUN : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject FiredGun;
    [SerializeField] private GameObject EnemyObj;
    [SerializeField] private LayerMask Enemy;

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
        if (Input.GetMouseButtonDown(0))
        {
            // Fare pozisyonunu dünya koordinatlarýna çeviriyoruz
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Z eksenini sýfýrlýyoruz çünkü 2D oyundayýz

            // Ray'in yönünü hesaplýyoruz
            Vector2 direction = (Vector2)mousePosition - rb.position;

            // Raycast iþlemi yapýyoruz
            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, 50, Enemy);

            // Eðer bir nesneye çarptýysak ve bu nesne EnemyObj ise
            if (hit.collider != null && hit.collider.gameObject == EnemyObj)
            {
                Debug.Log("Enemy is hit");
                EnemyObj.GetComponent<Enemy>().SlowDown();
            }
        }
    }
}
