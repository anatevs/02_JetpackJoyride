using System;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace GameCore
{
    public sealed class MapSection : MonoBehaviour
    {
        public event Action OnBorderAchieved;

        public event Action<int> OnInitPosSet;

        public float LeftBorderShift => _leftBorderShift;

        public float LeftCameraBorder
        {
            get => _leftCameraBorder;
            set => _leftCameraBorder = value;
        }

        [SerializeField]
        private Tilemap _sectionTilemap;

        private float _rightBorderShift;

        private float _leftBorderShift;

        private float _leftCameraBorder;

        private void Awake()
        {
            _rightBorderShift = (_sectionTilemap.size.x
                + _sectionTilemap.origin.x) * _sectionTilemap.cellSize.x;

            _leftBorderShift = -_sectionTilemap.origin.x * _sectionTilemap.cellSize.x;
        }

        private void Update()
        {
            if (GetRightBorderX() <= _leftCameraBorder)
            {
                OnBorderAchieved?.Invoke();
            }
        }

        public void PlaceLeftBorderToX(float x)
        {
            transform.position = new Vector3(
                x + _leftBorderShift,
                transform.position.y,
                transform.position.z);
        }

        public float GetRightBorderX()
        {
            return transform.position.x + _rightBorderShift;
        }

        public void InvokeOnInitPosSet(int mapOrder)
        {
            OnInitPosSet?.Invoke(mapOrder);
        }
    }
}