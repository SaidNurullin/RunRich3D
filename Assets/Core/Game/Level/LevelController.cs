using Game.Plane;
using Game.PlayerCharacter;
using UnityEngine;
using UnityEngine.Splines;

namespace Game.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private GameObject planePrefab;
        [SerializeField] private GameObject playerPrefab;
        [SerializeField] private SplineContainer container;

        private PlayerController playerController;

        private bool isFinished = false;

        private PlaneMovement plane;

        private void Start()
        {
            GameObject planeObj = Instantiate(planePrefab, transform);
            plane = planeObj.GetComponent<PlaneMovement>();
            plane.OnFinished.AddListener(ProcessFinish);

            GameObject player = Instantiate(playerPrefab, planeObj.transform);
            playerController = player.GetComponent<PlayerController>();
            playerController.OnLose.AddListener(Lose);
        }

        private void FixedUpdate()
        {
            if (isFinished) return;
            plane.Move(container, Time.fixedDeltaTime);
        }

        private void ProcessFinish()
        {
            isFinished = true;
            playerController.Finish();
        }

        private void Lose()
        {
            isFinished = true;
        }
    }
}
