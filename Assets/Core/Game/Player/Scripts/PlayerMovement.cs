using UnityEngine;

namespace Game.PlayerCharacter
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform _transform;
        [SerializeField] private float movementSpeed = 5f;
        [SerializeField] private float movementSmoothness = 10f;
        [SerializeField] private float maxDistanceFromCenter = 2f;

        private float _targetX;

        private void Awake()
        {
            _targetX = _transform.localPosition.x;
        }

        public void Move(float direction, float deltaTime)
        {
            _targetX += direction * movementSpeed * deltaTime;

            _targetX = Mathf.Clamp(
                _targetX,
                -maxDistanceFromCenter,
                maxDistanceFromCenter
            );

            Vector3 position = _transform.localPosition;

            position.x = Mathf.Lerp(
                position.x,
                _targetX,
                1f - Mathf.Exp(-movementSmoothness * deltaTime)
            );

            _transform.localPosition = position;
        }
    }
}