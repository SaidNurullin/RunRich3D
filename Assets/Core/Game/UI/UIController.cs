using ButchersGames;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject menu;

    public void Play()
    {
        levelManager.Init();
        menu.SetActive(false);
        levelManager.StartLevel();
    }
}
