using cln;
using cln.Sources.Services;
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
        
        Services.GetDataService().Set("TEST_KEY_INT", 1);
        Services.GetDataService().Set("TEST_KEY_FLOAT", 1.234f);
        Services.GetDataService().Set("TEST_KEY_BOOL", false);
        Services.GetDataService().Set("TEST_KEY_STRING", "test string");
        
        Dbg.Log(Services.GetDataService().Get<int>("TEST_KEY_INT"));
        Dbg.Log(Services.GetDataService().Get<float>("TEST_KEY_FLOAT"));
        Dbg.Log(Services.GetDataService().Get<bool>("TEST_KEY_BOOL"));
        Dbg.Log(Services.GetDataService().Get<string>("TEST_KEY_STRING"));
    }

    public void EndGame()
    {
        _gameController.Destroy();
        _gameController = null;
    }
}