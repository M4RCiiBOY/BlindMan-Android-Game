
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 desPos = target.position + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, desPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;


        transform.LookAt(target);
    }
}