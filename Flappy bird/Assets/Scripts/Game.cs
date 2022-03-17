using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private PipeSpawner _pipeSpawner;

    public delegate void RestartTheGame();
    public event RestartTheGame OnRestartTheGame;

    public delegate void GameOver();
    public event GameOver OnGameOver;

    public delegate void GameStartScreen();
    public event GameStartScreen OnGameStartScreen;

    private void Start()
    {
        Time.timeScale = 0;
        OnGameStartScreen?.Invoke();
    }

    private void OnEnable()
    {
        _bird.OnGameOver += GameIsOver;
    }

    private void OnDisable()
    {
        _bird.OnGameOver -= GameIsOver;
    }

    public void StartGame()
    {
       // OnStartTheGame?.Invoke();
        Time.timeScale = 1;
        _bird.ResetBird();
        _pipeSpawner.ResetSpawner();
    }

    public void RestartGame()
    {
        OnRestartTheGame?.Invoke();
        _pipeSpawner.ResetSpawner();
        StartGame();
    }

    public void GameIsOver()
    {
        OnGameOver?.Invoke();
        Time.timeScale = 0;
    }


}
