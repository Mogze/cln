using cln;
using cln.Sources.Services;
using GooglePlayGames;
using UnityEngine;
using zehreken.i_cheat;

public class Main : MonoBehaviour
{
    private GameController _gameController;
    public static Main Instance { get; private set; }
    private AdService _adService;

    void Start()
    {
        Application.targetFrameRate = 30;
        Instance = this;
        
        Services.Initialize();
        PlayGamesPlatform.Activate();
        
        Social.localUser.Authenticate(OnAuthenticate);
    }

    void Update()
    {
        if (_gameController != null)
        {
            _gameController.Update(Time.deltaTime);
        }
    }

    public void StartGame()
    {
        _gameController = new GameController();
    }

    public void EndGame()
    {
        _gameController.Destroy();
        _gameController = null;
    }

    public void OnAuthenticate(bool success)
    {
        Dbg.Log("Successfully connected to Google Play Games");
        Social.ShowLeaderboardUI();
    }
}