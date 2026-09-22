using ButchersGames;
using UnityEngine;

public class UIController : Singleton<UIController>
{
    [SerializeField] private LevelManager levelManager;
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject restart;
    [SerializeField] private GameObject next;

    public void Play()
    {
        levelManager.Init();
        menu.SetActive(false);
        restart.SetActive(false);
        next.SetActive(false);
        levelManager.StartLevel();
    }

    public void OpenRestartMenu()
    {
        restart.SetActive(true);
    }

    public void OpenNextMenu()
    {
        next.SetActive(true);
    }
}
