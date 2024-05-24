using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float circleCastRadius = 0.5f; // Dairesel rayýn yarýçapý
    [SerializeField] private LayerMask wallLayer; // Duvar katmanýný ayarlamak için
    private bool isWall = true;
    [SerializeField] private float minAngle; // Minimum açý
    [SerializeField] private float maxAngle;
    private Vector2 targetPosition;
    private Vector2 moveDirection;
    private LineRenderer lineRenderer;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
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
    private void movement()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angleX = Vector2.Angle(Vector2.right, mousePosition - rb.position);
        float angleY = Vector2.Angle(Vector2.up, mousePosition - rb.position);

        // Hem x hem y düzleminde belirli bir açýya sahipse hareket et
        if (angleX >= minAngle && angleX <= maxAngle && angleY >= minAngle && angleY <= maxAngle)
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


    //// Hedef pozisyona ulaþtýðýnda dur
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
