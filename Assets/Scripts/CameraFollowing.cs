using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowing : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private Vector2 offset;
    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    private void LateUpdate()
    {
        transform.position = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, transform.position.z);
    }

}
