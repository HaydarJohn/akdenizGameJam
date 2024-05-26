using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst.CompilerServices;
using UnityEngine;


public class MainPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float currentSpeed;
    [SerializeField] private float initialSpeed;
    [SerializeField] public float acceleration;
    [SerializeField] private float circleCastRadius = 0.5f; // Dairesel ray�n yar��ap�
    [SerializeField] private LayerMask wallLayer; // Duvar katman�n� ayarlamak i�in
    [SerializeField] private LayerMask deskLayer; // Duvar katman�n� ayarlamak i�in
    private bool isWall = true;
    [SerializeField] private float minAngle; // Minimum a��
    [SerializeField] private float maxAngle;
    private Vector2 targetPosition;
    private Vector2 moveDirection;
    private LineRenderer lineRenderer;
    private RaycastHit2D previusHit;
    public const double PI = 3.14159265359;
    [SerializeField] private GameObject desk;
    [SerializeField] private TextMeshProUGUI InteractText;
    [SerializeField] private TextMeshProUGUI closeMapText;
    [SerializeField] private GameObject map;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        previusHit = Physics2D.CircleCast(rb.position, circleCastRadius, moveDirection, speed * Time.fixedDeltaTime, wallLayer);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseMap();
            closeMapText.gameObject.SetActive(false);
        }
        DrawLineToMouse();
        CheckCollisionWithCircleCast();
        CheckInteract();

    }
    private void FixedUpdate()
    {
        movement();
        if (!isWall)
        {
            // Mevcut hızımızı kademeli olarak artırıyoruz
            currentSpeed += acceleration;

            // Maksimum hızı aşmamak için sınırlandırıyoruz
            currentSpeed = Mathf.Min(currentSpeed, speed);

            // Hareket yönünde hızımızı uyguluyoruz
            rb.velocity = moveDirection * currentSpeed;
        }
    }

    private void DrawLineToMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, mousePosition);
    }

    public double fixAngle(double angle)
    {
        if (angle > 360)
        {
            return angle - 360;
        }
        else if (angle < 0)
        {
            return angle + 360;
        }
        else
        {
            return angle;
        }
    }

    private bool validAngle(Vector2 mouse, Vector2 normal)
    {
        double deltaAngle = Vector2.Angle(mouse, normal);

        return 80 > deltaAngle;

    }

    private void CheckInteract()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (Vector2)mousePosition - rb.position;

        RaycastHit2D hit = Physics2D.Raycast(rb.position, direction, 1, wallLayer);

        if (hit.collider != null && hit.collider.gameObject == desk)
        {
            InteractText.gameObject.SetActive(true);
            Debug.Log("Map i açmak için tıkla");
            if (Input.GetMouseButtonDown(0))
            {
                closeMapText.gameObject.SetActive(true);
                OpenMap();
                Debug.Log("Map i açıldı");
            }
        }
        else
        {
            InteractText.gameObject.SetActive(false);
        }

    }
    private void movement()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float deltaX = previusHit.point.x - rb.position.x;
        float deltaY = previusHit.point.y - rb.position.y;
        Vector2 normal = new Vector2(-deltaX, -deltaY);
        Vector2 relativeMouse = mousePosition - rb.position;

        if (validAngle(relativeMouse, normal))
        {
            if (Input.GetKey(KeyCode.Space) && isWall)
            {
                currentSpeed = initialSpeed;
                targetPosition = mousePosition;
                moveDirection = (targetPosition - rb.position).normalized;
                //rb.velocity = moveDirection * speed;
                isWall = false;
            }
        }
    }

    private void CheckCollisionWithCircleCast()
    {
        if (!isWall)
        {
            RaycastHit2D hit = Physics2D.CircleCast(rb.position, circleCastRadius, moveDirection, speed * Time.fixedDeltaTime, wallLayer);
            Debug.Log(hit.point);
            if (hit.collider != null)
            {
                StopMovement();
                isWall = true;
                previusHit = Physics2D.CircleCast(rb.position, circleCastRadius, moveDirection, speed * Time.fixedDeltaTime, wallLayer);
                Debug.Log("Wall hit by CircleCast");
            }
        }
    }

    private void StopMovement()
    {
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    private void CloseMap()
    {
        map.SetActive(false);
    }
    private void OpenMap()
    {
        map.SetActive(true);
    }
}
