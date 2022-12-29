using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : Platform
{
    public float moveSpeed;
    private bool m_canmoveleft;
    private bool m_canmoveright;

    protected override void Start()
    {
        base.Start();
        float rand = Random.Range(0f, 1f);
        if(rand<=0.5)
        {
            m_canmoveleft = true;
            m_canmoveright = false;
        }
        else if(rand>0.5)
        {
            m_canmoveright = true;
            m_canmoveleft = false;
        }
    }

    private void FixedUpdate()
    {
        float curSpeed = 0;
        if (!m_rb) return;
        if(m_canmoveleft == true)
        {
            curSpeed = -moveSpeed;
        }else if (m_canmoveright == true)
        {
            curSpeed = moveSpeed;
        }
        m_rb.velocity = new Vector2(curSpeed, 0f);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(Gametag.LeftCorner.ToString()))
        {
            m_canmoveleft = false;
            m_canmoveright = true;
        }else if (col.CompareTag(Gametag.RightCorner.ToString()))
        {
            m_canmoveleft = true;
            m_canmoveright = false;
        }
    }
}
