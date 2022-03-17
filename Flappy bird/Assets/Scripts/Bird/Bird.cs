using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BirdMovement))]

public class Bird : MonoBehaviour
{
    private BirdMovement _birdMovement;
    private int _score;

    public delegate void ScoreChanged(int score);
    public event ScoreChanged OnScoreChanged;

    public delegate void GameOver();
    public event GameOver OnGameOver;

    private void Start()
    {
        _birdMovement = GetComponent<BirdMovement>();
    }

    public void ResetBird()
    {
        _score = 0;
        OnScoreChanged?.Invoke(_score);
        _birdMovement.ResetMovement();
    }

    public void IncreaseScore()
    {
        _score++;
        OnScoreChanged?.Invoke(_score);
    }

    public void Die()
    {
        OnGameOver?.Invoke();
    }

}
