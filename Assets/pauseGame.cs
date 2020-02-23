using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ScriptableObjectArchitecture;

public class pauseGame : MonoBehaviour
{

    public static bool isPaused = false;
    public GameEvent onPauseGE;
    public GameEvent onResumeGE;
    public static event Action onPauseGame;
    public static event Action onResumeGame;

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        onPauseGE.Raise();
        onPauseGame?.Invoke();
    }

    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1f;
        onResumeGE.Raise();
        onResumeGame?.Invoke();
    }
}
