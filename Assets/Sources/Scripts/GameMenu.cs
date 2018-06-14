using System;
using UnityEngine;
using UnityEngine.UI;

namespace cln
{
    public class GameMenu : Menu, IGameScoreListener, IHighScoreListener
    {
        [SerializeField] private Elements _elements;
        private GameEntity _listener;

        private void Start()
        {
        }

        private void OnEnable()
        {
            _listener = Contexts.sharedInstance.game.CreateEntity();
            _listener.AddGameScoreListener(this);
            _listener.AddHighScoreListener(this);
        }

        private void Update()
        {
        }

        public void OnGameScore(GameEntity entity, int value)
        {
            _elements.ScoreText.text = value.ToString();
        }

        public void OnHighScore(GameEntity entity, int value)
        {
            _elements.HighScoreText.text = "High:" + value;
        }

        [Serializable]
        private struct Elements
        {
            public Text ScoreText;
            public Text HighScoreText;
            public Button PauseButton;
        }
    }
}