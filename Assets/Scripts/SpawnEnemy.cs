using System.Collections;
using System;
using UnityEngine;

namespace DotShooting
{
    public class SpawnEnemy : SingletonMonoBehaviour<SpawnEnemy>
    {
        [SerializeField] GameObject _cubeEnemy;
        [SerializeField] GameObject _smallBallEnemy;
        [SerializeField] GameObject _bigBallEnemy;
        GameObject[] _wave;
        int _sumofEnemy = 1;
        float _moveSpeed = 3.0f;

        float _timer = 0f;
        float _spawnRate = 1.5f;

        private void Spawn()
        {
            if (_timer <= 0f)
            {
                GenerateEnemy();
                _timer = _spawnRate;
            }
            else
                _timer -= Time.deltaTime;
        }

        private void GenerateEnemy()
        {
            var rand  = new System.Random();
            int index = rand.Next(0, 10);
            int type  = rand.Next(0, 10) % 2; 
            if (_sumofEnemy % 10 == 0)
            {
                var f = Instantiate(_bigBallEnemy);
                f.SetActive(true);
                f.transform.SetParent(this.transform);
                f.transform.localPosition = new Vector3(1.0f, -430, 0);
                f.GetComponent<EnemyControl>()._moveSpeed = _moveSpeed / 3;
                f.GetComponent<EnemyControl>()._score = 1000;
                f.GetComponent<EnemyControl>()._HP = 20;
                _timer = 10.0f;
            }
            else if(type % 2 == 0 ) 
            {
                var f = Instantiate(_cubeEnemy);
                f.SetActive(true);
                f.transform.SetParent(this.transform);
                f.transform.localPosition = new Vector3(1.0f, -95 * index + index, 0);
                f.GetComponent<EnemyControl>()._moveSpeed = _moveSpeed;
                f.GetComponent<EnemyControl>()._score = 300;
                f.GetComponent<EnemyControl>()._HP = 3;
            }
            else 
            {
                var f = Instantiate(_smallBallEnemy);
                f.SetActive(true);
                f.transform.SetParent(this.transform);
                f.transform.localPosition = new Vector3(1.0f, -95 * index + index, 0);
                f.GetComponent<EnemyControl>()._moveSpeed = _moveSpeed;
                f.GetComponent<EnemyControl>()._score = 100;
                f.GetComponent<EnemyControl>()._HP = 1;
            }
            
            _sumofEnemy++;
        }

        private void UpdataSpawn() 
        {
            if(_sumofEnemy == 30)
            {
                if (_spawnRate > 0.3f)
                    _spawnRate -= 0.3f;
                if (_moveSpeed < 9.0f)
                    _moveSpeed += 1.5f;
                _sumofEnemy = 0;
            }
        }

        void Start()
        {

        }

        void FixedUpdate()
        {
            UpdataSpawn();
            Spawn();
        }
    }
}