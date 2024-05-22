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
        int _preSum = 0;
        float _moveSpeed = 3.0f;

        int _offset = 50;
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
            int index = rand.Next(1, 9);
            int type  = index % 2; 
            if (_sumofEnemy % 10 == 0)
            {
                var f = Instantiate(_bigBallEnemy);
                f.SetActive(true);
                f.transform.SetParent(this.transform);
                f.transform.localPosition = new Vector3(1.0f, -430, 0);
                f.GetComponent<EnemyControl>()._moveSpeed = _moveSpeed / 2;
                f.GetComponent<EnemyControl>()._score = 1000;
                f.GetComponent<EnemyControl>()._HP = _sumofEnemy;
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
            if(_sumofEnemy / _offset != _preSum / _offset)
            {
                if (_spawnRate > 0.5f)
                    _spawnRate -= 0.5f * (_sumofEnemy / _offset);
                if (_moveSpeed < 8.0f)
                    _moveSpeed += 1.0f * (_sumofEnemy / _offset);
            }
            _preSum = _sumofEnemy;
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