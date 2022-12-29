using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpFoce;
    public float moveSpeed;
    private Platform m_platform;
    private float movingLimitX;
    private Rigidbody2D m_rb;

    public Platform Platform { get => m_platform; set => m_platform = value; }
    public float MovingLimitX { get => movingLimitX; }
    public void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MovingHandle();
    }
    public void Jump()
    {
        if (!GameManager.Instance || GameManager.Instance.state !=GameState.Playing) return;
        if (!m_rb || m_rb.velocity.y > 0 || !m_platform ) return;
        if(m_platform is BreakablePlatform)
        {
            m_platform.PlatformAction();
        }
        m_rb.velocity = new Vector2(m_rb.velocity.x, jumpFoce);
        if(AudioController.Instance)
        {
            AudioController.Instance.PlaySound(AudioController.Instance.jump);
        }
    }
    private void MovingHandle()
    {
        if (!GamepadController.Instance || !m_rb || !GameManager.Instance||GameManager.Instance.state != GameState.Playing) return;
        if(GamepadController.Instance.CanMoveLeft && transform.position.x >- 2.3)
        {
            m_rb.velocity = new Vector2(-moveSpeed, m_rb.velocity.y);
        }else if(GamepadController.Instance.CanMoveRight && transform.position.x<2.3)
        {
            m_rb.velocity = new Vector2(moveSpeed, m_rb.velocity.y);
        }else
        {
            m_rb.velocity = new Vector2(0, m_rb.velocity.y);
            
        } 
    }
    public void hellooo()
    {
        Debug.Log("Hello");
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag(Gametag.Collectable.ToString()))
        {
            var collectable = col.GetComponent<Collectable>();
            if(collectable)
            {
                collectable.Trigger();
                Debug.Log("goi trigger");
            }
        }
    }
}
