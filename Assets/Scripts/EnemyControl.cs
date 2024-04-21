using System.Collections;
using System;
using UnityEngine;

namespace DotShooting
{
    public class EnemyControl : MonoBehaviour
    {
        [SerializeField] GameObject _bullet;

        float _timer = 0.0f;

        //インスタンス化したときにここの数値を設定するようにする
        float _shootingRate = 0.4f;
        float _score = 100;
        float _HP = 1;

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
                PlayerControl.instance._score += _score;
                _HP--;
                if (_HP == 0)
                    Destroy(this.gameObject);
            }
        }

        void Update()
        {
            ShootBullet();
        }
    }
}