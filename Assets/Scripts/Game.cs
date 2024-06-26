using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndScreen _endScreen;
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _bulletPool;
    [SerializeField] private EnemyGenerator _enemyGenerator;

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
        _enemyGenerator.StopGenerateEnemy();

        Time.timeScale = 0f;

        if (_endScreen.TryGetComponent(out CanvasGroup canvasGroup))
            canvasGroup.blocksRaycasts = true;

        _endScreen.Open();
    }

    private void OnRestartButtonClicked()
    {
        ResetPools();
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
        _player.Reset();
        Time.timeScale = 1f;

        _enemyGenerator.StartGenerateEnemy();
    }

    private void ResetPools()
    {
        _bulletPool.Reset();
        _enemyPool.Reset();
    }
}