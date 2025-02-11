using UnityEngine;
using UnityEngine.InputSystem;

namespace GameCore
{
    [RequireComponent(typeof(Rigidbody2D))]
    public sealed class Player : MonoBehaviour,
        ILeftScreenAlignment
    {
        [SerializeField]
        private float _relativeCameraPos = 0.25f;

        [SerializeField]
        private float _speedY;

        private Vector2 _initPos;

        private Rigidbody2D _rigidbody;

        private Vector2 _currentVelocity;

        

        private bool _isControllingStarted;

        private const string GAMEPLAY_INPUT_MAP = "Gameplay";

        private InputActionMap _gameplayActionMap;

        public Vector2 InitPos
        {
            get => _initPos;
            set => _initPos = value;
        }

        public void AlignXToScreen(float leftCameraBorder, float cameraHalfWidth)
        {
            var xPos = leftCameraBorder + _relativeCameraPos * 2 * cameraHalfWidth;

            _initPos.x = xPos;
            _initPos.y = transform.position.y;

            SetToInitPosX();
        }

        public void SetToInitPosX()
        {
            transform.position = _initPos;
        }

        public void SetIsPlaying(bool isPlaying)
        {
            if (isPlaying)
            {
                _gameplayActionMap.Enable();

                //_birdAnimation.SetActive(true);

                //_birdAnimation.SetFlapping();

                //if (_lastTerrainCollider != null)
                //{
                //    _lastTerrainCollider.enabled = true;
                //}
            }
            else
            {
                _gameplayActionMap.Disable();

                _isControllingStarted = false;
            }
        }

        public void SetIsMoving(bool isMoving)
        {
            if (isMoving)
            {
                _rigidbody.isKinematic = false;
                _rigidbody.velocity = _currentVelocity;
            }
            else
            {
                _currentVelocity = _rigidbody.velocity;
                _rigidbody.isKinematic = true;
            }
        }

        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Start()
        {
            _gameplayActionMap = GetComponent<PlayerInput>()
                .actions.FindActionMap(GAMEPLAY_INPUT_MAP);

            //SetIsPlaying(false);
            //SetIsMoving(false);

            SetIsPlaying(true);
            SetIsMoving(true);
        }

        private void RestrictYBorder(float yBorder)
        {
            if (Mathf.Abs(transform.position.y) >= Mathf.Abs(yBorder))
            {
                transform.position = new Vector2(
                    transform.position.x,
                    yBorder);
            }
        }

        void OnMoveUp()
        {
            Debug.Log("move up");

            _rigidbody.velocity = Vector2.up * _speedY;
            _isControllingStarted = true;

            //PlaySound(BirdSoundType.Flap);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //if (collision.transform.name != _collisionConfig.TerrainName &&
            //    collision.transform.name != _collisionConfig.BackgroundName)
            //{
            //    Debug.LogWarning("Name of terrain or background" +
            //        " tilemap in config doesn't match collided object name");
            //}

            //if (collision.transform.name == _collisionConfig.TerrainName)
            //{
            //    PlaySound(BirdSoundType.Hit);

            //    _birdAnimation.SetFall();

            //    _lastTerrainCollider = collision.collider;

            //    _lastTerrainCollider.enabled = false;
            //}
            //else if (collision.transform.name == _collisionConfig.BackgroundName)
            //{
            //    _birdAnimation.SetActive(false);
            //    PlaySound(BirdSoundType.Die);
            //}

            //SetIsPlaying(false);

            //OnRoundEnded?.Invoke();
        }

        //private void PlaySound(BirdSoundType soundType)
        //{
        //    AudioManager.Instance.PlaySound(soundType);
        //}
    }
}