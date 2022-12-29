using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unFollowCam : MonoBehaviour
{
    private Vector3 m_startingPos;
    void Start()
    {
        m_startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = m_startingPos;
    }
}
