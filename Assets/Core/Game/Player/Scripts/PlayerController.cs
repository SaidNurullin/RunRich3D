using System;
using UnityEngine;
using UnityEngine.Events;

namespace Game.PlayerCharacter
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private PlayerMovement playerMovement;
        [SerializeField] private CollectablesController collectablesController;

        [NonSerialized] public UnityEvent OnLose = new();

        private Vector2 move;
        private bool isFinished = false;

        private void Start()
        {
            collectablesController.OnBalanceEnd.AddListener(Lose);
        }

        public void Update()
        {
            if (isFinished) return;
            move = InputManager.Instance.GetControls().Player.Move.ReadValue<Vector2>();
        }

        public void FixedUpdate()
        {
            if (isFinished) return;
            playerMovement.Move(move.x, Time.fixedDeltaTime);
        }

        public void Finish()
        {
            isFinished = true;
        }

        public void Lose()
        {
            isFinished = true;
            OnLose.Invoke();
        }
    }
}
