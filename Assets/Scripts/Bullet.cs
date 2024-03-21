using UnityEngine;
using UnityEngine.UI;

namespace DotShooting
{
    class Bullet : MonoBehaviour
    {
        Rigidbody2D _rb;
        float _bulletSpeed = 7.0f;

        private void BulletMove()
        {
            _rb.velocity = this.transform.right * _bulletSpeed;
            if (this.transform.position.x > 9.5f)
                Destroy(this.gameObject);
        }

        void Start()
        {
            _rb = this.GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            BulletMove();
        }
    }
}