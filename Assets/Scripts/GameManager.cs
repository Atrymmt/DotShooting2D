using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace DotShooting
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {
        [SerializeField] GameObject _pausePanel;
        [SerializeField] Button _restartBtn;
        [SerializeField] Button _exitBtn;

        bool _isPause = false;


        public void GameQuit()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        public void GameOver()
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("GameOver");
        }
        
        private void PauseGame()
        {
            _pausePanel.SetActive(true);
            Time.timeScale = 0;
        }

        private void ResumeGame()
        {
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
        }

        void Start()
        {
            _restartBtn.onClick.AddListener(() => ResumeGame());
            _exitBtn.onClick.AddListener(() => GameQuit());
        }

        void Update()
        {
            if(Input.GetKey(KeyCode.Escape) && !_isPause )
                PauseGame();
            if(Input.GetKey(KeyCode.Escape) && _isPause )
                ResumeGame();
        }
    }
}