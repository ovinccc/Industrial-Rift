using UnityEngine;

public class TimelineDisappearPlatform : MonoBehaviour
{
    public Timeline activeTimeline = Timeline.Present; // exists only in Present

    SpriteRenderer sr;
    Collider2D[] cols;

    void Awake()
    {
        sr = GetComponentInChildren<SpriteRenderer>(); // works even if sprite is on a child
        cols = GetComponentsInChildren<Collider2D>();  // toggles colliders on parent/children
    }

    void OnEnable()
    {
        TimelineManager.OnTimelineChanged += Apply;
        if (TimelineManager.Instance != null)
            Apply(TimelineManager.Instance.currentTimeline);
    }

    void OnDisable()
    {
        TimelineManager.OnTimelineChanged -= Apply;
    }

    void Apply(Timeline t)
    {
        bool shouldExist = (t == activeTimeline);

        if (sr != null) sr.enabled = shouldExist;

        foreach (var c in cols)
            if (c != null) c.enabled = shouldExist;
    }
}