using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using JokerGho5t.MessageSystem;
using UnityEngine.SceneManagement;

public class ControlSystem : MonoBehaviour
{
    public delegate void SimpleEvent();
    public static event SimpleEvent OnUpdate;

    [Range(0, 1)]
    private float TimeScaleForSlow = 0.3f;
    [Range(0, 10)]
    private float TimeForTimeSlow = 0.5f;

    private void OnEnable()
    {
        Message.AddListener("SlowTime", () => StartCoroutine(Slowtime()));
    }

    private void OnDisable()
    {
        Message.RemoveListener("SlowTime", () => StartCoroutine(Slowtime()));
    }

    void Update()
    {
        OnUpdate?.Invoke();
    }

    IEnumerator Slowtime()
    {
        Time.timeScale = TimeScaleForSlow;

        yield return new WaitForSeconds(TimeForTimeSlow);

        Time.timeScale = 1;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
