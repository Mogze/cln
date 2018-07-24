using System;
using cln.Sources.Services;
using UnityEngine;
using UnityEngine.UI;

namespace cln
{
    public class MainMenu : Menu, IGameScoreListener
    {
        [SerializeField] private Elements _elements;
        private GameEntity _listener;

        private void Start()
        {
            Debug.Log(GetType());

            _elements.PlayButton.onClick.AddListener(OnClickPlay);
            _elements.LeaderboardButton.onClick.AddListener(OnClickLeaderboard);
            _elements.ToggleSoundButton.onClick.AddListener(OnClickToggleSound);
            _elements.LastScoreText.text = "Last:" + 0;
            _elements.HighScoreText.text = "High:" + PlayerPrefs.GetInt("high_score");
            _elements.SoundImages[0].SetActive(Services.GetAudioService().IsMuted);
            _elements.SoundImages[1].SetActive(!Services.GetAudioService().IsMuted);
        }

        private void OnEnable()
        {
            _listener = Contexts.sharedInstance.game.CreateEntity();
            _listener.AddGameScoreListener(this);
            _elements.HighScoreText.text = "High:" + PlayerPrefs.GetInt("high_score");
        }

        private void OnClickPlay()
        {
            Debug.Log("on click play");
            GameObject.Find("Main").GetComponent<Main>().StartGame();

            MenuManager.Close(typeof(MainMenu));
            MenuManager.Show(typeof(GameMenu));
            Services.GetAdService().RequestBanner();
            Services.GetAdService().RequestInterstitial();
        }

        private void OnClickLeaderboard()
        {
            Services.GetGpgService().ShowLeaderboard();
        }
        
        private void OnClickToggleSound()
        {
            Services.GetAudioService().ToggleSound();
            _elements.SoundImages[0].SetActive(Services.GetAudioService().IsMuted);
            _elements.SoundImages[1].SetActive(!Services.GetAudioService().IsMuted);
        }

        public void OnGameScore(GameEntity entity, int value)
        {
            _elements.LastScoreText.text = "Last:" + value;
        }

        private void OnDestroy()
        {
            _elements.PlayButton.onClick.RemoveListener(OnClickPlay);
            _elements.LeaderboardButton.onClick.RemoveListener(OnClickLeaderboard);
            _elements.ToggleSoundButton.onClick.RemoveListener(OnClickToggleSound);
        }

        [Serializable]
        private struct Elements
        {
            public Text LastScoreText;
            public Text HighScoreText;
            public Button PlayButton;
            public Button LeaderboardButton;
            public Button ToggleSoundButton;
            public GameObject[] SoundImages;
        }
    }
}