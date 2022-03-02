using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                            
using UnityEngine.SceneManagement;      
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject titleScreen;          // with button Play
    public GameObject gameOverScreen;       //  with button Restart

    public TextMeshProUGUI scoreText;       // Score text (canvas)

    public Button _play;       
    public Button _restart;     
    

    public bool isGameActive; 
    public bool isGameStart;    
    private int score;      // Score

    void Start()
    {
        isGameStart = true; 
    }

    void Update()
    {
        if (isGameActive == false && isGameStart == false)  
        {
            GameOver();     // if game end => show GameOverScreen
        }
        
    }

    public void UpdateScore(int scoreToAdd)     // Update Score
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }



    public void StartGame()     // if press button "Play"
    {
        titleScreen.gameObject.SetActive(false);    // switch off titleScreen
        scoreText.gameObject.SetActive(true);       // switch on scoreText
        isGameActive = true;    
        isGameStart = false; 
    }

    public void GameOver()  // if the Player is destroyed
    {
        gameOverScreen.gameObject.SetActive(true);  // switch on gameOverScreen with button "Restart"
    }

    public void RestartGame()   // if press button "Restart"
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart this scene
    }
}
