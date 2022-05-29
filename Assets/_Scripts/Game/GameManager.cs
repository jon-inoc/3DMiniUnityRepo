using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MainMenu, Play, Win, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField] private AudioClip gameWin_SFX;
    [SerializeField] private AudioClip gameLost_SFX;

    [HideInInspector] public static GameState gameState = new GameState();
    private string _sceneName;
    private int currentPoints = 0;

    #region Delegates

    public static event myDelegate onLevelStart;
    public static event myDelegate onLevelFinished;
    public static event myDelegate onGameLost;
    public static event myDelegate onToMainMenu;

    #endregion

    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else { Destroy(gameObject); }

        Application.targetFrameRate = 60;
    }

    private void Start()
    {
        _sceneName = SceneManager.GetActiveScene().name;
    }
    // Start is called before the first frame update
    public void ToMainMenu()
    {
        onToMainMenu?.Invoke();
        gameState = GameState.MainMenu;
    }

    public void StartLevel()
    {
        onLevelStart?.Invoke();
        AudioManager.Instance.PlayGameMusic();
        gameState = GameState.Play;

    }

    public void GameOver() 
    {
        onGameLost?.Invoke();
        AudioManager.Instance.PlayGameSFX(gameLost_SFX);
        gameState = GameState.GameOver;
    }

    public void GameWin() 
    {
        onLevelFinished?.Invoke();
        AudioManager.Instance.PlayGameSFX(gameWin_SFX);
        gameState = GameState.Win;
    }

    public void GameFinish() 
    {
        if (currentPoints < 100)
            GameOver();
    }

    public void ResetLevel() 
    {
        SceneManager.LoadScene(_sceneName);
    }

    public void UpdatePoints(int currentPoints) 
    {
        if (currentPoints >= 100)
            GameWin();
    }
}
