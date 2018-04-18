using cln;
using UnityEngine;

public class Main : MonoBehaviour
{
    private GameController _gameController;
    
    void Start()
    {
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
        _gameController = null;
    }
}