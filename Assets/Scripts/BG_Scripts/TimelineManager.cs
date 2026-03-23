using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Timeline { Past, Present }

public class TimelineManager : MonoBehaviour
{
    public static TimelineManager Instance { get; private set; }

    public Timeline currentTimeline = Timeline.Present;

    public static event Action<Timeline> OnTimelineChanged;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void SetTimeline(Timeline t)
    {
        currentTimeline = t;
        OnTimelineChanged?.Invoke(currentTimeline);
    }
}
