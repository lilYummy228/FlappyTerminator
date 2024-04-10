using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += ShowScore;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= ShowScore;
    }

    private void ShowScore(int score)
    {
        _score.text = score.ToString();
    }
}
