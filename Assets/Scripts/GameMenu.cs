using System;
using UnityEngine;
using UnityEngine.UI;

namespace cln
{
    public class GameMenu : Menu
    {
        [SerializeField] private Elements _elements;

        private void Start()
        {
        }

        private void Update()
        {
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