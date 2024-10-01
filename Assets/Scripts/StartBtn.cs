using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBtn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        GameManager.singelton.playerLives = 3;
        GameManager.singelton.level = 1;
        GameManager.singelton.LivesUI.SetActive(true);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
        
    }
}
