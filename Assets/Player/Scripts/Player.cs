using UnityEngine;

namespace GameCore
{
    public sealed class Player : MonoBehaviour,
        ILeftScreenAlignment
    {
        [SerializeField]
        private float _relativeCameraPos = 0.25f;

        private Vector2 _initPos;

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
    }
}