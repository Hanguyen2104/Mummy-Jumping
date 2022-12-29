using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;
    public int startinngPlatform;
    public float xSpawnOffset;
    public float minYspawnPos;
    public float maxYspawnPos;
    public Platform[] platformPrefabs;
    public CollectableItem[] collectableItem;

    private Platform m_lastPlatformSpawned;
    private List<int> m_platformLandIds;
    private int  m_score;

    public Player player;
    public static GameManager Instance{get; private set; }

    public Platform LastPlatformSpawned { get => m_lastPlatformSpawned; set => m_lastPlatformSpawned = value; }
    public List<int> PlatformLandIds { get => m_platformLandIds; set => m_platformLandIds = value; }
    public int Score { get => m_score;  }

    private void Awake()
    {
        if(Instance)
        {
            Destroy(Instance);
        }
        else
        {
            Instance = this;
            
        }
        m_platformLandIds = new List<int>();
    }
    public  void Start()
    {
        state = GameState.Starting;
        if (AudioController.Instance)
        {
            AudioController.Instance.PlayBackGroundMusic();
        }

    }
    
    public void PlayGame()
    {
        Debug.Log("play game");
        if(UIManager.Instance)
        {
            UIManager.Instance.ShowGamePlay(true);
        }
        
        Invoke("PlayGameInvk", 1f);
        Invoke("PlatformInit", 0.5f);
    }
    private void PlayGameInvk()
    {
        state = GameState.Playing;
        if (player)
        {
            player.Jump();
        }
           
    }
    private void PlatformInit()
    {
       
        m_lastPlatformSpawned = player.Platform;
     
        for(int i=0;i<startinngPlatform;i++)
        {
            SpawnPlatform();
        }
    }
    
    public bool IsPlatformLanded(int id)
    {
        if (PlatformLandIds == null || m_platformLandIds.Count <= 0) return false;
        return PlatformLandIds.Contains(id) ;
    }
    public void hellooo()
    {
        Debug.Log("Hello");
    }
    public void AddScore(int scoreToAdd)
    {
        if (state != GameState.Playing) return;
        m_score += scoreToAdd;
        Pref.bestScore = m_score;
        if(UIManager.Instance)
        {
            UIManager.Instance.updateScore(m_score);
        }
    }
    public void SpawnCollectable(Transform spawnpoint)
    {
        if (collectableItem == null || collectableItem.Length <= 0||state !=GameState.Playing) return;
        int randIdx = Random.Range(0,collectableItem.Length);
        var collectItem = collectableItem[randIdx];

        if (collectItem==null) return;
        float randcheck = Random.Range(0f, 1f);
        if(randcheck<=collectItem.spawnRate && collectItem.collectablePrefab)
        {
            var cClone = Instantiate(collectItem.collectablePrefab, spawnpoint.position, Quaternion.identity);
            cClone.transform.SetParent(spawnpoint);
        }
    }
    public void SpawnPlatform()
    {
        
        if (!player || platformPrefabs == null || platformPrefabs.Length <= 0) return;
        
        float spawnPosX = Random.Range(-(2.3f - xSpawnOffset), (2.3f - xSpawnOffset));
        float disBetweenPlat = Random.Range(minYspawnPos, maxYspawnPos);
        float spawnPosY = m_lastPlatformSpawned.transform.position.y + disBetweenPlat;

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, 0f);

        int randIndex = Random.Range(0, platformPrefabs.Length);
        var platformPrefab = platformPrefabs[randIndex];
        if (!platformPrefab) return;
        var platformClone = Instantiate(platformPrefab,spawnPos,Quaternion.identity);
        platformClone.ID = m_lastPlatformSpawned.ID + 1;
        m_lastPlatformSpawned = platformClone;
    }
}
