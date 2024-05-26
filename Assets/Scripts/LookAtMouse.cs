using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    public Camera mainCamera; // Kamerayý atamanýz gerekecek
    public LayerMask layerMask; // Iþýnýn hangi katmanlara çarpabileceðini belirlemek için
    public float rotationSpeed = 10f; // Karakterin ne kadar hýzlý döneceðini belirlemek için

    void Update()
    { // Fare pozisyonunu al
        Vector3 mousePosition = Input.mousePosition;

        // Fare pozisyonunu dünya koordinatlarýna çevir
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        mousePosition.z = 0; // Z eksenini sabit tut

        // Karakterin pozisyonunu al
        Vector3 characterPosition = transform.position;

        // Fare pozisyonuna doðru bir yön vektörü hesapla
        Vector3 direction = mousePosition - characterPosition;

        // Yön vektörüne göre karakteri döndür
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }

    void LookAtMousee()
    {
        // Fare pozisyonundan bir ýþýn oluþtur
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayDistance;

        // Iþýnýn bir düzlemle kesiþtiðini kontrol et
        if (groundPlane.Raycast(ray, out rayDistance))
        {
            // Iþýnýn kesiþtiði noktayý al
            Vector3 point = ray.GetPoint(rayDistance);
            // Karakterin sadece yatay düzlemde dönmesini saðlamak için hedef noktayý belirle
            Vector3 lookPoint = new Vector3(point.x, transform.position.y, point.z);

            // Karakteri bu noktaya bakacak þekilde döndür
            Vector3 direction = (lookPoint - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
    }
}
