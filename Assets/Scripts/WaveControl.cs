using System.Collections;
using System;
using UnityEngine;

namespace DotShooting
{
    public class WaveControl : SingletonMonoBehaviour<WaveControl>
    {
        [SerializeField] GameObject _cubeEnemy;
        [SerializeField] GameObject _smallBallEnemy;
        [SerializeField] GameObject _bigBallEnemy;
        GameObject[] _wave;
        int _NumofWave = 0;


        private bool _isWave = false;

        private void GenerateWave()
        {
            //敵をインスタンス化し配列に格納．フラグを立てる
            _isWave = true;
            _NumofWave++;
            var rand = new System.Random();
            int NumofEnemy = rand.Next(3, 9);
            _wave = new GameObject[NumofEnemy];
            for (int i = 0; i < NumofEnemy; i++) 
            {
                var f = Instantiate(_cubeEnemy);
                f.SetActive(true);
                f.transform.SetParent(this.transform);
                f.transform.localPosition = new Vector3(1.0f + i, 0, 0);
            }
        }

        void Start()
        {

        }

        void Update()
        {
            if(!_isWave)
            {
                //GenerateWave();
            }
        }
    }
}