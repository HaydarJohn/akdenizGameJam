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
            // Fare pozisyonunu d�nya koordinatlar�na �eviriyoruz
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; // Z eksenini s�f�rl�yoruz ��nk� 2D oyunday�z

            // Ray'in y�n�n� hesapl�yoruz
            Vector2 direction = (Vector2)mousePosition - rb.position;

            // Raycast i�lemi yap�yoruz
            RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, 50, Enemy);

            // E�er bir nesneye �arpt�ysak ve bu nesne EnemyObj ise
            if (hit.collider != null && hit.collider.gameObject == EnemyObj)
            {
                Debug.Log("Enemy is hit");
                EnemyObj.GetComponent<Enemy>().SlowDown();
            }
        }
    }
}
