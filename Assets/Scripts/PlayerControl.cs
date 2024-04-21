using System.Collections;
using System;
using UnityEngine;
using TMPro;

namespace DotShooting
{
    public class PlayerControl : SingletonMonoBehaviour<PlayerControl>
    {
        [SerializeField] GameObject _bullet;
        [SerializeField] GameObject _heartPanel;
        [SerializeField] GameObject _heart;
        [SerializeField] TextMeshProUGUI _totalScore;

        float _playerSpeed;
        float _timer;
        float _shootingRate;
        GameObject[] _life;

        public int Å@_HP;
        public float _score;

        private void PlayerMove()
        {
            if (Input.GetKey(KeyCode.W) && this.transform.position.y < 4.0f)
            {
                this.transform.position += this.transform.up * _playerSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S) && this.transform.position.y > -4.5f)
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

        private void OnTriggerEnter2D(Collider2D collider)         //ìGíeÇ…Ç‘Ç¬Ç©Ç¡ÇΩèÍçá
        {
            if (collider.gameObject.name == "EnemyBullet(Clone)")
            {
                Destroy(collider.gameObject);
                _HP--;
                _life[_HP].SetActive(false);
                if (_HP == 0)
                {
                    Destroy(this.gameObject);
                    GameManager.instance.GameOver();
                }
            }
        }
        
        private void OnCollisionEnter2D(Collision2D collision)      //ìGÇ∆Ç‘Ç¬Ç©Ç¡ÇΩèÍçá
        {
            if(collision.gameObject.name != "PlayerBullet(Clone)")
            {
                _HP--;
                _life[_HP].SetActive(false);
                if (_HP == 0)
                {
                    Destroy(this.gameObject);
                    GameManager.instance.GameOver();
                }
            }
        }

        private void ShowHeart(int hp)
        {
            for (int i = 0; i < hp; i++)
            {
                var f = Instantiate(_heart);
                f.SetActive(true);
                f.transform.SetParent(_heartPanel.transform);
                f.transform.position = new Vector3(_heartPanel.transform.position.x + 0.7f + 0.5f * i, _heartPanel.transform.position.y + 0.08f, 0);
                _life[i] = f;
            }
        }

        void Awake()
        {
            //ÉVÅ[ÉìëJà⁄å„ÇÃÇΩÇﬂÇ…ílÇÃèâä˙âªÇÇ±Ç±Ç≈çsÇ§
            _playerSpeed = 5.0f;
            _timer = 0.0f;
            _shootingRate = 0.2f;
            _HP = 3;
        Å@Å@_score = 0;
            Time.timeScale = 1.0f;
        }

        void Start()
        {
            _life = new GameObject[_HP];
            ShowHeart(_HP);
            _totalScore.text = _score.ToString();
        }

        void FixedUpdate()
        {
            PlayerMove();
            ShootBullet();
            _totalScore.text = _score.ToString();
        }
    }
}