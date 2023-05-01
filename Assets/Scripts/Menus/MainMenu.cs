using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MenuBase<MainMenu>
{
    public static event Action LoadOptionsMenu;
    [SerializeField] Button PlayButton;
    [SerializeField] Button OptionsButton;
    [SerializeField] Button ExitButton;

    private void Start()
    {
        if (PlayButton)
        {
            PlayButton.onClick.RemoveAllListeners();
            PlayButton.onClick.AddListener(delegate { StartPlay(PlayButton); });
        }
        if (OptionsButton)
        {
            OptionsButton.onClick.RemoveAllListeners();
            OptionsButton.onClick.AddListener(delegate { ShowOptionsMenu(OptionsButton); });
        }
        if (ExitButton)
        {
            ExitButton.onClick.RemoveAllListeners();
            ExitButton.onClick.AddListener(delegate { ExitGame(ExitButton); });
        }
        LoadEventSystem.Instance.LoadMainMenu += Instance_LoadMainMenu;
    }

    private void OnDestroy()
    {
        LoadEventSystem.Instance.LoadMainMenu -= Instance_LoadMainMenu;
    }

    private void Instance_LoadMainMenu()
    {
        menuCanvas.gameObject.SetActive(true);
    }

    private void StartPlay(Button playButton)
    {
        // load playable scene
        SceneManager.LoadScene(1, LoadSceneMode.Additive);
        menuCanvas.gameObject.SetActive(false);
    }

    private void ShowOptionsMenu(Button optionsButton)
    {
        LoadOptionsMenu?.Invoke();
        menuCanvas.gameObject.SetActive(false);
    }

    private void ExitGame(Button exitButton)
    {
        Application.Quit();
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
            EditorApplication.isPlaying = false;
#endif
    }
}
