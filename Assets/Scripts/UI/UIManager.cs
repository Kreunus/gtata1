﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject LevelSelection;
    [SerializeField] private GameObject SettingsMenu;
    [SerializeField] private GameObject PauseMenu;

    private void Start()
    {
        GameManager.Instance.OnGameStateChanged.AddListener(HandleGameStateChanged);
    }
    void HandleGameStateChanged(GameManager.GameState currentState, GameManager.GameState previousState)
    {
        if (currentState == GameManager.GameState.PREGAME)
        {
            PauseMenu.SetActive(false);
        }

        if (previousState == GameManager.GameState.PREGAME && currentState == GameManager.GameState.RUNNING)
        {
            PauseMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (currentState == GameManager.GameState.RUNNING)
        {
            LevelSelection.SetActive(false);
            SettingsMenu.SetActive(false);
            PauseMenu.SetActive(false);
            MainMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
        }

        if (previousState == GameManager.GameState.RUNNING && currentState == GameManager.GameState.PAUSED)
        {
            LevelSelection.SetActive(false);
            SettingsMenu.SetActive(false);
            MainMenu.SetActive(false);
            PauseMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }

    internal void HandleSetting()
    {
        MainMenu.SetActive(false);
        PauseMenu.SetActive(false);
        LevelSelection.SetActive(false);
        ///////////////////////////////
        SettingsMenu.SetActive(true);
    }

    public void HandleLevelSelect()
    {
        MainMenu.SetActive(false);
        PauseMenu.SetActive(false);
        PauseMenu.SetActive(false);
        //////////////////////////////
        LevelSelection.SetActive(true);
    }

    public void HandleMenuExecution(GameManager.GameState state)
    {
        if (state == GameManager.GameState.PAUSED)
        {
            LevelSelection.SetActive(false);
            SettingsMenu.SetActive(false);
            MainMenu.SetActive(false);
            /////////////////////////
            PauseMenu.SetActive(true);
        }

        else if (state == GameManager.GameState.PREGAME)
       {
            LevelSelection.SetActive(false);
            SettingsMenu.SetActive(false);
            PauseMenu.SetActive(false);
            /////////////////////////
            MainMenu.SetActive(true);
        }
    }

    public void OnClickPlay()
    {
        LevelSelection.SetActive(false);
    }

    public void HandleQuit()
    {
        Application.Quit();
    }
}