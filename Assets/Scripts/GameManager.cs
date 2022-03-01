using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                            
using UnityEngine.SceneManagement;      
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject titleScreen;          //  Стартовый экран с кнопкой Старт
    public GameObject gameOverScreen;       //  Конец игры с кнопкой Рестарт

    public TextMeshProUGUI scoreText;       // Счет

    public Button _play;        //  Кнопка Старт
    public Button _restart;     //  Кнопка Рестарт
    

    public bool isGameActive;   // Проверка активна ли игра, она же и конец игры
    public bool isGameStart;    // Внутренняя проверка старта игры после нажатия кнопки Start
    private int score;      // переменная со значения в Score

    void Start()
    {
        isGameStart = true;     // Старт игры получает, что игра стартанула
    }

    void Update()
    {
        if (isGameActive == false && isGameStart == false)      // Если игра не стартанула и игра проиграна
        {
            GameOver();     // Включаем функцию Конец Игры
        }
        
    }

    public void UpdateScore(int scoreToAdd)     // Обновляем счет
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }



    public void StartGame()     // если жмем на кнопку Играть
    {
        titleScreen.gameObject.SetActive(false);    // Выключаем главный экран Старт
        scoreText.gameObject.SetActive(true);       // Включаем счет
        isGameActive = true;    // Игра активна
        isGameStart = false;    // Игра начата нет
    }

    public void GameOver()  // Останавливаем игру по проигрышу
    {
        gameOverScreen.gameObject.SetActive(true);  // Активируем окно с канвасом Игра Окончена (кнопка Рестарт)
    }

    public void RestartGame()   // если жмем на кнопку Рестарт
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Перезапускается текущая сцена
    }
}
