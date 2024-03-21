using System.Collections;
using System;
using UnityEngine;

namespace DotShooting
{
    public class PlayerControl : SingletonMonoBehaviour<PlayerControl>
    {
        [SerializeField] GameObject _bullet;

        Rigidbody2D _rb;
        float _playerSpeed = 4.0f;

        float _timer = 0.0f;
        float _shootingRate = 0.2f;

        private void PlayerMove()
        {
            if (Input.GetKey(KeyCode.W) && this.transform.position.y < 5.0f)
            {
                this.transform.position += this.transform.up * _playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) && this.transform.position.y > -5.0f)
            {
                this.transform.position -= this.transform.up * _playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D) && this.transform.position.x < 8.0f)
            {
                this.transform.position += this.transform.right * _playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A) && this.transform.position.x > -8.0f)
            {
                this.transform.position -= this.transform.right * _playerSpeed * Time.deltaTime;
            }
        }

        private void ShootBullet()
        {
            if (Input.GetKey(KeyCode.Space) && _timer <= 0.0f)
            {
                var f = Instantiate(_bullet);
                f.SetActive(true);
                f.transform.position = new Vector3(this.transform.position.x + 0.85f, this.transform.position.y, 0);
                _timer = _shootingRate;
            }

            if (_timer > 0)
                _timer -= Time.deltaTime;
        }

        void Start()
        {
            _rb = this.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            PlayerMove();
            ShootBullet();
        }
    }
}