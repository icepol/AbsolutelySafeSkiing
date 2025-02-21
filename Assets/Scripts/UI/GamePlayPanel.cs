using pixelook;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayPanel : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void OnEnable()
    {
        EventManager.AddListener(Events.SCORE_CHANGED, OnScoreUpdated);
    }

    private void OnDisable()
    {
        EventManager.RemoveListener(Events.SCORE_CHANGED, OnScoreUpdated);
    }

    private void OnScoreUpdated()
    {
        _scoreText.text = GameState.Score.ToString();
    }
}
