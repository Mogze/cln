using cln;
using UnityEngine;

public class Main : MonoBehaviour
{
    private GameController _gameController;
    public static Main Instance { get; private set; }

    void Start()
    {
        Instance = this;
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