using UnityEngine;
using TMPro;

public class Player : MonoBehaviour, IPointGetter
{
    [SerializeField] private int _currentPoints = 0;
    [SerializeField] private TextMeshProUGUI txt_points;

    [SerializeField] private AudioClip hurtSFX;
    [SerializeField] private AudioClip pointsSFX;

    public void GetPoints(int points)
    {
        _currentPoints += points;
        AudioManager.Instance.PlayGameSFX(pointsSFX);

        UpdateScore();
    }

    public void BotTakePoints(int points) 
    {
        _currentPoints -= points;
        AudioManager.Instance.PlayGameSFX(hurtSFX);

        if (_currentPoints < 0)
            GameManager.Instance.GameOver();

        UpdateScore();
    }

    private void UpdateScore() 
    {
        txt_points.text = "Player Score: " + _currentPoints.ToString();
        GameManager.Instance.UpdatePoints(_currentPoints);
    }
}
