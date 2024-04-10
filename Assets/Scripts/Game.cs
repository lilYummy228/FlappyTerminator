using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private ObjectPool _enemyPool;
    [SerializeField] private ObjectPool _bulletPool;

    private void OnEnable()
    {
        _player.GameOver += OnGameOver;
        _startScreen.PlayButtonClicked += OnPlayButtonClicked;
        _endScreen.RestartButtonClicked += OnRestartButtonClicked;
    }


    private void OnDisable()
    {
        _player.GameOver -= OnGameOver;
        _startScreen.PlayButtonClicked -= OnPlayButtonClicked;
        _endScreen.RestartButtonClicked -= OnRestartButtonClicked;
    }

    private void Start()
    {
        Time.timeScale = 0f;
        _startScreen.Open();
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;

        if (_endScreen.TryGetComponent(out CanvasGroup canvasGroup))
            canvasGroup.blocksRaycasts = true;

        _endScreen.Open();
    }

    private void OnRestartButtonClicked()
    {
        _enemyPool.Reset();
        _bulletPool.Reset();
        _endScreen.Close();
        StartGame();
    }

    private void OnPlayButtonClicked()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _player.Reset();
    }
}
