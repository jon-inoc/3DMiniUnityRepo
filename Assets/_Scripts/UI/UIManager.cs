using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenuUI = default;
    [SerializeField] private GameObject inGameUI = default;
    [SerializeField] private GameObject levelFinishedUI = default;
    [SerializeField] private GameObject gameLostUI = default;
    [SerializeField] private GameObject controlUI = default;

    private enum UIState { MainMenu, Game, LevelFinish, GameLost };
    private UIState uiState = new UIState();

    private void OnEnable()
    {
        GameManager.onLevelStart += OnLevelStart;
        GameManager.onLevelFinished += OnLevelFinished;
        GameManager.onGameLost += OnGameLost;
        GameManager.onToMainMenu += OnToMainMenu;
    }
    private void OnDisable()
    {
        GameManager.onLevelStart -= OnLevelStart;
        GameManager.onLevelFinished -= OnLevelFinished;
        GameManager.onGameLost -= OnGameLost;
        GameManager.onToMainMenu -= OnToMainMenu;
    }

    private void Awake()
    {
        uiState = UIState.MainMenu;
    }

    private void Start()
    {
        UIStateChanged();
    }

    private void OnToMainMenu()
    {
        uiState = UIState.MainMenu;
        UIStateChanged();
    }

    private void OnLevelStart()
    {
        uiState = UIState.Game;
        UIStateChanged();
    }

    private void OnLevelFinished()
    {
        uiState = UIState.LevelFinish;
        UIStateChanged();
    }

    private void OnGameLost()
    {
        uiState = UIState.GameLost;
        UIStateChanged();
    }

    private void PauseGame() 
    {
        Time.timeScale = 0;
    }

    private void ResumeGame() 
    {
        Time.timeScale = 1;
    }

    private void UIStateChanged()
    {
        inGameUI.SetActive(uiState == UIState.Game);
        levelFinishedUI.SetActive(uiState == UIState.LevelFinish);
        gameLostUI.SetActive(uiState == UIState.GameLost);
        mainMenuUI.SetActive(uiState == UIState.MainMenu);

        if (uiState == UIState.Game)
        {
            ResumeGame();
            controlUI.SetActive(true);
        }
        else
        {
            PauseGame(); 
            controlUI.SetActive(false);
        }
    }

}
