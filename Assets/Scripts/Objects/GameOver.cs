using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField] private Text highestScore;
    [SerializeField] private Text currentScoreText;
    [SerializeField] private ScoreCounter currentScore;
    private bool _gameIsOver;
    
    private void Start()
    {
        Player.player.Died += EndGame;
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (_gameIsOver == false)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene(0);
        else if (Input.GetKeyDown(KeyCode.Mouse0))
            SceneManager.LoadScene(1);
    }

    private void EndGame()
    {
        gameObject.SetActive(true);
        int score = Saver.GetSavedScore();
        if(currentScore.Score > score)
        {
            Saver.SaveScore(currentScore.Score);
            score = currentScore.Score;
        }
        
        highestScore.text = $"Highest score: {score}";
        currentScoreText.text = $"Score: {currentScore.Score}";
        _gameIsOver = true;
        Time.timeScale = 0;
    }
}
