using System;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Splines;

namespace Game.Plane
{
    public class PlaneMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Transform _transform;
        [NonSerialized] public UnityEvent OnFinished = new();


        private Vector3 targetPosition;
        private Quaternion targetRotation;
        private float currentDistance;

        public void Move(SplineContainer container, float deltaTime)
        {
            CalculateTargetPositionAndRotation(container);
            _transform.position = targetPosition;
            _transform.rotation = targetRotation;
            currentDistance += speed * deltaTime;
        }

        private void CalculateTargetPositionAndRotation(SplineContainer container)
        {
            var spline = container.Spline;

            float4x4 local_to_world = container.transform.localToWorldMatrix;
            float total_length = SplineUtility.CalculateLength(spline, local_to_world);

            float clampedDistance = Mathf.Clamp(currentDistance, 0, total_length);
            if(Mathf.Abs(total_length - clampedDistance) < 0.1f)
            {
                OnFinished.Invoke();
            }
            float t = clampedDistance / total_length;

            SplineUtility.Evaluate(spline, t,
                out float3 pos, out float3 tangent, out float3 up);

            Quaternion rot = Quaternion.LookRotation(tangent, up);
            targetPosition = pos;
            targetRotation = rot;
        }
    }
}
