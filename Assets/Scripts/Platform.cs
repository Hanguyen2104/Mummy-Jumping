using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public Transform CSpawnpoint;
    private int m_id;
    public Player m_player;
    public Rigidbody2D m_rb;
    // Start is called before the first frame update
   public int ID { get => m_id; set=>m_id = value; }

    protected virtual void Awake()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    protected virtual  void Start()
    {
        if(!GameManager.Instance)
        {
            m_player = GameManager.Instance.player;
        }
        if(CSpawnpoint)
        {
            GameManager.Instance.SpawnCollectable(CSpawnpoint);
        }
    }
    public virtual void PlatformAction()
    {

    }
}
