﻿using System.Collections.Generic;
using UnityEngine;

namespace GameCore
{
    public class LeftScreenDisposition : MonoBehaviour
    {
        private List<ILeftScreenAlignment> _leftScreenAlignments;

        private Camera _camera;

        private float _leftCameraBorder;

        public void Construct(List<ILeftScreenAlignment> leftScreenAlignments)
        {
            _leftScreenAlignments = leftScreenAlignments;
        }

        private void Start()
        {
            _camera = Camera.main;

            _leftCameraBorder = GetLeftCameraBorder();

            foreach(var alignment in _leftScreenAlignments)
            {
                alignment.AlignXToScreen(_leftCameraBorder);
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

                foreach (var alignment in _leftScreenAlignments)
                {
                    alignment.AlignXToScreen(leftCameraBorder);
                }
            }
        }

        private float GetLeftCameraBorder()
        {
            return _camera.transform.position.x
                - _camera.aspect * _camera.orthographicSize;
        }
    }
}