using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MenuBase<OptionsMenu>
{
    public static event Action LoadMainMenu;

    [SerializeField] Button BackButton;

    private void Start()
    {
        if (BackButton)
        {
            BackButton.onClick.RemoveAllListeners();
            BackButton.onClick.AddListener(delegate { BackToMain(BackButton); });
        }
        LoadEventSystem.Instance.LoadOptionsMenu += Instance_LoadOptionsMenu;
    }

    private void OnDestroy()
    {
        LoadEventSystem.Instance.LoadOptionsMenu -= Instance_LoadOptionsMenu;
    }

    private void BackToMain(Button backButton)
    {
        LoadMainMenu?.Invoke();
        menuCanvas.gameObject.SetActive(false);
    }

    private void Instance_LoadOptionsMenu()
    {
        menuCanvas.gameObject.SetActive(true);
    }
}
