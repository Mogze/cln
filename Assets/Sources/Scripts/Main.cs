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
        Instance = this;
        
        _adService = new AdService();
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
}