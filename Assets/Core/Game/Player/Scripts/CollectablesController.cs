using AYellowpaper.SerializedCollections;
using Game.Collectables;
using Game.Sound;
using System;
using UnityEngine;
using UnityEngine.Events;

public class CollectablesController : MonoBehaviour
{
    [SerializeField] private int minBalance = 20;
    [SerializeField] private SerializedDictionary<CollectableTypes, SoundPlayer> sounds;
    [NonSerialized] public UnityEvent<int> OnBalanceUpdated = new();
    [NonSerialized] public UnityEvent OnBalanceEnd = new();

    private int currentBalance;

    private void Start()
    {
        currentBalance = minBalance;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out Collectable collectable)) return;

        Debug.Log("collect");
        sounds[collectable.collectableType].PlaySound(true);
        currentBalance += collectable.value;
        if(currentBalance <= 0)
        {
            Debug.Log("balance ended");
            currentBalance = 0;
            OnBalanceEnd.Invoke();
        }
        OnBalanceUpdated.Invoke(currentBalance);
        Destroy(other.gameObject);
    }
}
