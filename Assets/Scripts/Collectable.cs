using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int scoreBonus;
    public GameObject explosionPb;

    public void Trigger()
    {
        if(!explosionPb)
        {
            Instantiate(explosionPb, transform.position, Quaternion.identity);
            Debug.Log("Da goi hieu ung");
        }
        Destroy(gameObject);
        Debug.Log("da huy");
        if(GameManager.Instance)
        {
            GameManager.Instance.AddScore(scoreBonus);
        }
        if(AudioController.Instance)
        {
            AudioController.Instance.PlaySound(AudioController.Instance.getCollectable);
        }
    }
}
