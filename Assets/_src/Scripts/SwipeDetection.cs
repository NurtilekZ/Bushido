using System.Collections;
using UnityEngine;

namespace _src.Scripts
{
    public class SwipeDetection : MonoBehaviour
    {
        [SerializeField] private float _minDistance = .2f;
        [SerializeField] private float _maxDistance = 1f;
        [SerializeField] [Range(0f,1f)] private float _directionThreshold = .9f;
        [SerializeField] private GameObject _trail;
        
        private InputManager _inputManager;

        private Vector2 _startPosition;
        private float _startTime;
        private Vector2 _endPosition;
        private float _endTime;
        
        private Coroutine _trailCoroutine;

        private void Awake()
        {
            _inputManager = InputManager.Instance;
        }

        private void OnEnable()
        {
            _inputManager.OnStartTouch += SwipeStart;
            _inputManager.OnEndTouch += SwipeEnd;
        }

        private void OnDisable()
        {
            _inputManager.OnStartTouch += SwipeStart;
            _inputManager.OnEndTouch += SwipeEnd;
        }

        private void SwipeStart(Vector2 position, float time)
        {
            _startPosition = position;
            _startTime = time;
            _trail.SetActive(true);
            _trail.transform.position = position;
            _trailCoroutine = StartCoroutine(Trail());
        }

        private IEnumerator Trail()
        {
            while (true)
            {
                _trail.transform.position = _inputManager.PrimaryPosition();
                yield return null;
            }
        }

        private void SwipeEnd(Vector2 position, float time)
        {
            _trail.SetActive(false);
            StopCoroutine(_trailCoroutine);
            _endPosition = position;
            _endTime = time;
            DetectSwipe();
        }

        private void DetectSwipe()
        {
            if (Vector3.Distance(_startPosition, _endPosition) >= _minDistance &&
                (_endTime - _startTime) <= _maxDistance)
            {
                Debug.Log("Swipe Detected");
                Debug.DrawLine(_startPosition, _endPosition, Color.red);
                Vector3 direction = _endPosition - _startPosition;
                Vector2 direction2D = new Vector2(direction.x, direction.y);
                SwipeDirection(direction2D);
            }
        }

        private void SwipeDirection(Vector2 direction)
        {
            if (Vector2.Dot(Vector2.up, direction) > _directionThreshold)
            {
                Debug.Log("Swipe up");
            } else if (Vector2.Dot(Vector2.down, direction) > _directionThreshold)
            {
                Debug.Log("Swipe Down");
            } else if (Vector2.Dot(Vector2.right, direction) > _directionThreshold)
            {
                Debug.Log("Swipe Right");
            } else if (Vector2.Dot(Vector2.left, direction) > _directionThreshold)
            {
                Debug.Log("Swipe Left");
            }
        }
    }
}