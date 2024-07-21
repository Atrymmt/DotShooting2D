using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DotShooting
{
    public class GameOver : SingletonMonoBehaviour<GameOver>
    {
        [SerializeField] TextMeshProUGUI _playerScore;
        [SerializeField] TextMeshProUGUI _playerHighScore;
        [SerializeField] Button _restartBtn;
        [SerializeField] Button _exitBtn;
        
        long _score = 0;
        long _highScore = 0;

        private void GameQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void ShowScore()
        {
            _score = PlayerControl._score;
            _highScore = PlayerControl._highScore;
            _playerScore.text = _score.ToString();

            if (_score == _highScore)
            {
                _playerHighScore.text = _highScore.ToString() + "   NEW!!!";
            }
            else
            {
                _playerHighScore.text = _highScore.ToString();
            }
        }


        void Start()
        {
            ShowScore();
            _restartBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));
            _exitBtn.onClick.AddListener(() => GameQuit());
        }

        void Update()
        {

        }
    }
}