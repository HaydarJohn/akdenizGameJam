using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Camera mainCamera; // Kameray� ataman�z gerekecek
    public LayerMask layerMask; // I��n�n hangi katmanlara �arpabilece�ini belirlemek i�in
    public float rotationSpeed = 10f; // Karakterin ne kadar h�zl� d�nece�ini belirlemek i�in

    void Update()
    { // Fare pozisyonunu al
        Vector3 mousePosition = Input.mousePosition;

        // Fare pozisyonunu d�nya koordinatlar�na �evir
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0; // Z eksenini sabit tut

        // Karakterin pozisyonunu al
        Vector3 characterPosition = transform.position;

        // Fare pozisyonuna do�ru bir y�n vekt�r� hesapla
        Vector3 direction = mousePosition - characterPosition;

        // Y�n vekt�r�ne g�re karakteri d�nd�r
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    void LookAtMousee()
    {
        // Fare pozisyonundan bir ���n olu�tur
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        // I��n�n bir d�zlemle kesi�ti�ini kontrol et
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            // I��n�n kesi�ti�i noktay� al
            Vector3 point = ray.GetPoint(rayDistance);
            // Karakterin sadece yatay d�zlemde d�nmesini sa�lamak i�in hedef noktay� belirle
            Vector3 lookPoint = new Vector3(point.x, transform.position.y, point.z);

            // Karakteri bu noktaya bakacak �ekilde d�nd�r
            Vector3 direction = (lookPoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
