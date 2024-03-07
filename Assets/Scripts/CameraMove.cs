using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public Transform target;

    public float deadZone = 1f;

    public float smoothSpeed = 5f;

    public Vector3 offset;

    private void Update()
    {
        Vector3 currentPosition = transform.position;

        Vector3 targetPosition = target.position + offset;

        float distanceX = Mathf.Abs(currentPosition.x - targetPosition.x);
        float distanceY = Mathf.Abs(currentPosition.y - targetPosition.y);

        if (distanceX > deadZone)
        {
            currentPosition.x = Mathf.Lerp(currentPosition.x, targetPosition.x, smoothSpeed * Time.deltaTime);
        }

        if (distanceY > deadZone)
        {
            currentPosition.y = Mathf.Lerp(currentPosition.y, targetPosition.y, smoothSpeed * Time.deltaTime);
        }

        transform.position = currentPosition;
    }
}
