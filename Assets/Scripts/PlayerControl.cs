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

        AudioSource _audio;
        float _playerSpeed;
        float _timer;
        float _shootingRate;
        GameObject[] _life;

        int _HP;
        int _offset = 10000;
        long _preScore = 0;
        public static long _score;

        private void PlayerMove()
        {
            Rigidbody2D _rb = GetComponent<Rigidbody2D>();
            float x = Input.GetAxis("Horizontal");
            float y = Input.GetAxis("Vertical");
            _rb.velocity = new Vector2 (x, y) * _playerSpeed;
        }

        private void ShootBullet()
        {
            if (Input.GetKey(KeyCode.Space) && _timer <= 0.0f)
            {
                _audio.Play(); 
                var f = Instantiate(_bullet);
                f.SetActive(true);
                f.transform.position = new Vector3(this.transform.position.x + 0.85f, this.transform.position.y - 0.19f, 0);
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
            if(collision.gameObject.tag == "Enemy")
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

        private void PowerUp(long score)
        {
            if (_shootingRate > 0.1f && (_preScore / _offset != score / _offset))
                _shootingRate -= 0.1f * (score / _offset);

            //if (_preScore / _offset != score / _offset)
            //{
            //    _HP++;
            //    ShowHeart(_HP);
            //}
            _preScore = score;
        }

        void Awake()
        {
            //ÉVÅ[ÉìëJà⁄å„ÇÃÇΩÇﬂÇ…ílÇÃèâä˙âªÇÇ±Ç±Ç≈çsÇ§
            _playerSpeed = 6.0f;
            _timer = 0.0f;
            _shootingRate = 0.6f;
            _HP = 5;
        Å@Å@_score = 0;
            Time.timeScale = 1.0f;
        }

        void Start()
        {
            _life = new GameObject[_HP];
            _audio = gameObject.GetComponent<AudioSource>();
            ShowHeart(_HP);
            _totalScore.text = _score.ToString();
        }

        void FixedUpdate()
        {
            PlayerMove();
            ShootBullet();
            _totalScore.text = _score.ToString();
            PowerUp(_score);
        }
    }
}