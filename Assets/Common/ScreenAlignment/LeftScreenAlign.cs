using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace GameCore
{
    public sealed class LeftScreenAlign : MonoBehaviour
    {
        private IEnumerable<ILeftScreenAlignment> _leftScreenAlignments;

        private Camera _camera;

        private float _leftCameraBorder;

        [Inject]
        public void Construct(IEnumerable<ILeftScreenAlignment> leftScreenAlignments)
        {
            _leftScreenAlignments = leftScreenAlignments;
        }

        private void Start()
        {
            _camera = Camera.main;

            _leftCameraBorder = GetLeftCameraBorder();

            var halfWidth = GetCameraHalfWidth();

            foreach(var alignment in _leftScreenAlignments)
            {
                alignment.AlignXToScreen(_leftCameraBorder, halfWidth);
            }
        }

        public void InitPositions()
        {
            var leftCameraBorder = GetLeftCameraBorder();

            if (_leftCameraBorder == leftCameraBorder)
            {
                foreach (var alignment in _leftScreenAlignments)
                {
                    alignment.SetToInitPosX();
                }
            }
            else
            {
                _leftCameraBorder = leftCameraBorder;

                var halfWidth = GetCameraHalfWidth();

                foreach (var alignment in _leftScreenAlignments)
                {
                    alignment.AlignXToScreen(leftCameraBorder, halfWidth);
                }
            }
        }

        private float GetLeftCameraBorder()
        {
            return _camera.transform.position.x
                - _camera.aspect * _camera.orthographicSize;
        }

        private float GetCameraHalfWidth()
        {
            return _camera.aspect * _camera.orthographicSize;
        }
    }
}