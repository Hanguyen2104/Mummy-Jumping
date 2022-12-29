using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow Instance;
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    private void Awake()
    {
        Instance = this;
    }

    public void FixedUpdate()
    {
        Follow();
    }
    public void Follow()
    {
        if (target == null || target.transform.position.y < transform.position.y) return;
        Vector3 targetpos = new Vector3(0f, target.transform.position.y, 0f) + offset;
        Vector3 smoothPos = Vector3.Lerp(transform.position, targetpos, smoothFactor * Time.deltaTime);
        transform.position = new Vector3(
            Mathf.Clamp(smoothPos.x, 0, smoothPos.x),
            Mathf.Clamp(smoothPos.y, 0, smoothPos.y),
            -10f);
    }
}
