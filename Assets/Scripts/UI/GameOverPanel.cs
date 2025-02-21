using pixelook;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField] private Text _scoreText;

    private void Start()
    {
        _scoreText.text = GameState.Score.ToString();
    }
}
