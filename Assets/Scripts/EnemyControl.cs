using System.Collections;
using System;
using UnityEngine;

namespace DotShooting
{
    public class EnemyControl : MonoBehaviour
    {
        [SerializeField] GameObject _bullet;

        float _timer;
        float _shootingRate = 0.4f;
        bool  _isBoss = false;

        //インスタンス化したときにここの数値を設定するようにする
        public float _moveSpeed;
        public long  _score;
        public float _HP;

        private void Move()
        {
            this.transform.position -= this.transform.right * _moveSpeed * Time.deltaTime;
            if(this.transform.position.x < -10f)
                Destroy(this.gameObject);
        }

        private void ShootBullet()
        {
            if (_timer <= 0.0f)
            {
                var f = Instantiate(_bullet);
                f.SetActive(true);
                f.transform.position = new Vector3(this.transform.position.x - 0.5f, this.transform.position.y, 0);
                _timer = _shootingRate;
            }

            if (_timer > 0)
                _timer -= Time.deltaTime;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.name == "PlayerBullet(Clone)")
            {
                Destroy(collision.gameObject);
                _HP--;
                if (_HP == 0)
                {
                    PlayerControl._score += _score;
                    Destroy(this.gameObject);
                }
            }
        }

        void Start()
        {
            _timer = 0f;
        }

        void FixedUpdate()
        {
            //ShootBullet();
            Move();
        }
    }
}