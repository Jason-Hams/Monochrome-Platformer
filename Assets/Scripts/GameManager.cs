using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager singelton;
    [SerializeField] private TextMeshProUGUI LiveCount;
    [SerializeField] public GameObject LivesUI;
   
    public int playerLives = 3;
    public int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        if (singelton == null)
        {
            singelton = this;
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        LiveCount.text = "X" + playerLives.ToString();
    }
    public void LevelComplete()
    {
       
        level += 1;
        SceneManager.LoadScene(level);
        if(level == 4)
        {
            LivesUI.SetActive(false);
        }
        
    }


    public void PlayerDie()
    {
        if(playerLives == 0)
        {
            GameOver();
        }
        else
        {
            LevelManager.singelton.PlayerSpawn();
            playerLives -= 1;
            Debug.Log(playerLives);
        }

    }

    private void GameOver()
    {
        LivesUI.SetActive(false);
        SceneManager.LoadScene(5);
        
    }

    public void GainLife()
    {
        playerLives += 1;
        Debug.Log(playerLives);
    }

}
