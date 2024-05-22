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
        [SerializeField] Button _restartBtn;
        [SerializeField] Button _exitBtn;

        private void GameQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        void Start()
        {
            long score = PlayerControl._score;
            _playerScore.text = score.ToString();
            _restartBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));
            _exitBtn.onClick.AddListener(() => GameQuit());
        }

        void Update()
        {

        }
    }
}