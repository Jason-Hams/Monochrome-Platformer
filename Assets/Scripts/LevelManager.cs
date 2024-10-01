using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    public static LevelManager singelton;

    private void Awake()
    {
        singelton = this;
        PlayerSpawn();
    }

    public void PlayerSpawn()
    {
        Instantiate(playerPrefab, spawnPoint);
        
    }

}
