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

        long _highScore = 0;

        private void GameQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void UpdateHighScore(long score)
        {
            if (score > _highScore)
            {
                _highScore = score;
                _playerHighScore.text = _highScore.ToString() + "   NEW!!!";
            }
        }


        void Start()
        {
            long score = PlayerControl._score;
            _playerScore.text = score.ToString();
            UpdateHighScore(score);
            _restartBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));
            _exitBtn.onClick.AddListener(() => GameQuit());
        }

        void Update()
        {

        }
    }
}