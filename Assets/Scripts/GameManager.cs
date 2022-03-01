using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;                            
using UnityEngine.SceneManagement;      
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    
    public GameObject titleScreen;          //  ��������� ����� � ������� �����
    public GameObject gameOverScreen;       //  ����� ���� � ������� �������

    public TextMeshProUGUI scoreText;       // ����

    public Button _play;        //  ������ �����
    public Button _restart;     //  ������ �������
    

    public bool isGameActive;   // �������� ������� �� ����, ��� �� � ����� ����
    public bool isGameStart;    // ���������� �������� ������ ���� ����� ������� ������ Start
    private int score;      // ���������� �� �������� � Score

    void Start()
    {
        isGameStart = true;     // ����� ���� ��������, ��� ���� ����������
    }

    void Update()
    {
        if (isGameActive == false && isGameStart == false)      // ���� ���� �� ���������� � ���� ���������
        {
            GameOver();     // �������� ������� ����� ����
        }
        
    }

    public void UpdateScore(int scoreToAdd)     // ��������� ����
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }



    public void StartGame()     // ���� ���� �� ������ ������
    {
        titleScreen.gameObject.SetActive(false);    // ��������� ������� ����� �����
        scoreText.gameObject.SetActive(true);       // �������� ����
        isGameActive = true;    // ���� �������
        isGameStart = false;    // ���� ������ ���
    }

    public void GameOver()  // ������������� ���� �� ���������
    {
        gameOverScreen.gameObject.SetActive(true);  // ���������� ���� � �������� ���� �������� (������ �������)
    }

    public void RestartGame()   // ���� ���� �� ������ �������
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ��������������� ������� �����
    }
}
