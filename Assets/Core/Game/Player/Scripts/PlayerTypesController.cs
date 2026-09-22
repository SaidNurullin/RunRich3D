using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.TextCore;

namespace Game.PlayerCharacter
{
    public enum PlayerTypes
    {
        None,
        Poor,
        Casual,
        Middle,
        Business,
        Cocktail,
        Bling
    }

    public class PlayerTypesController : MonoBehaviour
    {
        [SerializeField] private CollectablesController collectablesController;
        [SerializeField] private Animator animator;
        [SerializeField] private SerializedDictionary<PlayerTypes, int> typesBalances;
        [SerializeField] private SerializedDictionary<PlayerTypes, GameObject> typesModels;
        [SerializeField] private SerializedDictionary<PlayerTypes, string> typesTriggers;

        private GameObject currentModel;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            currentModel = typesModels[PlayerTypes.Poor];
            currentModel.SetActive(true);
            string trigger = typesTriggers[PlayerTypes.Poor];
            animator.SetTrigger(trigger);
            collectablesController.OnBalanceUpdated.AddListener(HandleBalance);
        }

        private void HandleBalance(int balance)
        {
            PlayerTypes _type = PlayerTypes.Poor;
            foreach (var item in typesBalances)
            {
                if (balance < item.Value) break;
                _type = item.Key;
            }

            currentModel.SetActive(false);
            currentModel = typesModels[_type];
            currentModel.SetActive(true);

            string trigger = typesTriggers[_type];
            animator.SetTrigger(trigger);
        }
    }
}
