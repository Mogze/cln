using System;
using UnityEngine;
using UnityEngine.UI;

namespace cln
{
    public class MainMenu : Menu
    {
        [SerializeField] private Elements _elements;

        void Start()
        {
            Debug.Log(GetType());
            
            _elements.PlayButton.onClick.AddListener(OnClickPlay);
        }

        void Update()
        {
        }

        private void OnClickPlay()
        {
            Debug.Log("on click play");
        }

        private void OnDestroy()
        {
            _elements.PlayButton.onClick.RemoveListener(OnClickPlay);
        }

        [Serializable]
        private struct Elements
        {
            public Text LastScoreText;
            public Text HighScoreText;
            public Button PlayButton;
        }
    }
}