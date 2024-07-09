using UnityEngine;
using UnityEngine.UI;

namespace DotShooting
{
    class Bullet : MonoBehaviour
    {
        Rigidbody2D _rb;
        float _bulletSpeed = 7.0f;

        bool _isPlayer;

        private void BulletMove()
        {
            if(_isPlayer)
                _rb.velocity = this.transform.right * _bulletSpeed;
            else
                _rb.velocity = - this.transform.right * _bulletSpeed;

            if (this.transform.position.x > 9.5f || this.transform.position.x < -9.5f)
                Destroy(this.gameObject);
        }

        void Start()
        {
            _rb = this.GetComponent<Rigidbody2D>();
            if (this.gameObject.name == "PlayerBullet(Clone)")
                _isPlayer = true;
            if (this.gameObject.name == "EnemyBullet(Clone)")
                _isPlayer = false;
        }

        void Update()
        {
            BulletMove();
        }
    }
}