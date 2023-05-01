using System;
using UnityEngine;

public class LoadEventSystem : MonoBehaviour
{
    /// <summary>
    /// Singleton of LoadEventSystem
    /// </summary>
    public static LoadEventSystem Instance { get; private set; }

    public event Action OnMainMenuLoad;
    public event Action OnMainMenuUnload;
    public event Action LoadMainMenu;
    public event Action OnOptionsMenuLoad;
    public event Action OnOptionsMenuUnload;
    public event Action LoadOptionsMenu;
    public event Action OnPlayScene1Load;
    public event Action OnPlayScene1Unload;
    

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        MainMenu.OnUILoaded += MainMenu_OnUILoaded;
        MainMenu.OnUIUnloaded += MainMenu_OnUIUnloaded;
        OptionsMenu.OnUILoaded += OptionsMenu_OnUILoaded;
        OptionsMenu.OnUIUnloaded += OptionsMenu_OnUIUnloaded;
        MainMenu.LoadOptionsMenu += Menu_LoadOptions;
        OptionsMenu.LoadMainMenu += OptionsMenu_LoadMainMenu;
        PauseMenu.LoadMainMenu += OptionsMenu_LoadMainMenu;
    }


    private void OnDestroy()
    {
        MainMenu.OnUILoaded -= MainMenu_OnUILoaded;
        MainMenu.OnUIUnloaded -= MainMenu_OnUIUnloaded;
        OptionsMenu.OnUILoaded -= OptionsMenu_OnUILoaded;
        OptionsMenu.OnUIUnloaded -= OptionsMenu_OnUIUnloaded;
        MainMenu.LoadOptionsMenu -= Menu_LoadOptions;
        OptionsMenu.LoadMainMenu -= OptionsMenu_LoadMainMenu;
        PauseMenu.LoadMainMenu += OptionsMenu_LoadMainMenu;
    }

    private void MainMenu_OnUILoaded()
    {
        if (Instance.OnMainMenuLoad is not null)
            Instance.OnMainMenuLoad();
    }

    private void MainMenu_OnUIUnloaded()
    {
        if (Instance.OnMainMenuUnload is not null)
            Instance.OnMainMenuUnload();
    }

    private void OptionsMenu_OnUILoaded()
    {
        if (Instance.OnOptionsMenuUnload is not null)
            Instance.OnOptionsMenuUnload();
    }

    private void OptionsMenu_OnUIUnloaded()
    {
        if (Instance.OnOptionsMenuLoad is not null)
            Instance.OnOptionsMenuLoad();
    }

    private void Menu_LoadOptions()
    {
        if (Instance.LoadOptionsMenu is not null)
            Instance.LoadOptionsMenu();
    }

    private void OptionsMenu_LoadMainMenu()
    {
        if (Instance.LoadMainMenu is not null)
            Instance.LoadMainMenu();
    }
}
