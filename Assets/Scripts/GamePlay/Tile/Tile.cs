using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Runner
{
    public class Tile : MonoBehaviour
    {



        [SerializeField] private List<Transform> _points = new List<Transform>();

        private float _speed;

        private GameObject _coin;
        private GameObject _bomb;
        private float _startSpawnBomb;
        private float _timer;
        private bool _isMove = true;

        void Start()
        {
            if (_coin == null || _bomb == null)
            {
                return;
            }

            int randomPointIndex = Random.Range(0, _points.Count);

            if (_timer < _startSpawnBomb)
            {
                CreateObject(randomPointIndex, _coin);
            }
            else
            {

                float changeSpawnBomb = 20 + _timer / 4;
                changeSpawnBomb = Mathf.Clamp(changeSpawnBomb, 0, 60);

                if (Random.Range(0, 100) < changeSpawnBomb)
                {
                    CreateObject(randomPointIndex, _bomb);
                }
                else
                {
                    CreateObject(randomPointIndex, _coin);
                }

            }

        }

        private void CreateObject(int randomPointIndex, GameObject objectType)
        {
            GameObject newObject = Instantiate(objectType, _points[randomPointIndex].position, Quaternion.identity);
            newObject.transform.SetParent(transform);
        }

        public void Initialize(GameObject coin, GameObject bomb, float startSpawnBomb, float timer)
        {
            if (coin == null || bomb == null)
            {
                return;
            }
            _coin = coin;
            _bomb = bomb;
            _startSpawnBomb = startSpawnBomb;
            _timer = timer;

        }


        void FixedUpdate()
        {
            if (_isMove == false)
            {
                return;
            }
            transform.Translate(Vector3.back * _speed * Time.fixedDeltaTime);
        }

        public void SetSpeed(float speed)
        {
            //Debug.Log(speed);
            if (speed < 0)
            {
                Debug.LogError("speed < 0");
                return;
            }
            _speed = speed;
        }

        public void SetMoving(bool state)
        {
            _isMove = state;
        }
    }
}