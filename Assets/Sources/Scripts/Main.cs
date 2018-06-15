using cln;
using cln.Sources.Services;
using UnityEngine;

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

    void OnGUI()
    {
        if (GUI.Button(new Rect(0f, 0f, 500f, 500f), "Show interstitial"))
        {
            Services.GetAdService().ShowInterstitial();
        }
    }

    public void EndGame()
    {
        _gameController.Destroy();
        _gameController = null;
    }
}