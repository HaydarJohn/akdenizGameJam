using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MainPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float circleCastRadius = 0.5f; // Dairesel ray�n yar��ap�
    [SerializeField] private LayerMask wallLayer; // Duvar katman�n� ayarlamak i�in
    private bool isWall = true;
    [SerializeField] private float minAngle; // Minimum a��
    [SerializeField] private float maxAngle;
    private Vector2 targetPosition;
    private Vector2 moveDirection;
    private LineRenderer lineRenderer;
    private RaycastHit2D previusHit;
    public const double PI = 3.14159265359;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
        previusHit = Physics2D.CircleCast(rb.position, circleCastRadius, moveDirection, speed * Time.fixedDeltaTime, wallLayer);
    }
    private void Update()
    {
        DrawLineToMouse();
        CheckCollisionWithCircleCast();

    }
    private void FixedUpdate()
    {
        movement();
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
        if(angle > 360)
        {
            return angle - 360;
        }
        else if( angle < 0)
        {
            return angle + 360;
        }
        else
        {
            return angle;
        }
    }

    private bool validAngle(Vector2 mouse,Vector2 normal)
    {
        double deltaAngle = Vector2.Angle(mouse , normal);

        return 80 > deltaAngle;
        
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
                targetPosition = mousePosition;
                moveDirection = (targetPosition - rb.position).normalized;
                rb.velocity = moveDirection * speed;
                isWall = false;
            }
        }
    }


    //// Hedef pozisyona ula�t���nda dur
    //if (!isWall && Vector2.Distance(rb.position, targetPosition) < 0.1f)
    //{
    //    StopMovement();
    //}


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
}
