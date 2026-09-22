using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform cameraPoint;

    void Start()
    {
        Transform cam = Camera.main.transform;
        cam.parent = cameraPoint;
        cam.position = cameraPoint.position;
        cam.rotation = cameraPoint.rotation;
    }

}
