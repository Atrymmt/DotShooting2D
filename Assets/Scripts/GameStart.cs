using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DotShooting
{
    public class GameStart : SingletonMonoBehaviour<GameStart>
    {

        [SerializeField] Button _startBtn;
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
            //float score = PlayerControl.instance._score;
            //_playerScore.text = score.ToString();
            _startBtn.onClick.AddListener(() => SceneManager.LoadScene("PlayScene"));
            _exitBtn.onClick.AddListener(() => GameQuit());
        }

        void Update()
        {

        }
    }
}