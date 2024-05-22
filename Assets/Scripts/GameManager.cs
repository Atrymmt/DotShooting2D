using System.Collections;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DotShooting
{
    public class GameManager : SingletonMonoBehaviour<GameManager>
    {

        public void GameOver()
        {
            Time.timeScale = 0f;
            SceneManager.LoadScene("GameOver");
        }
        
        void Start()
        {

        }

        void Update()
        {
            
        }
    }
}