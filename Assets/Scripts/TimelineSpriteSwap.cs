using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TimelineSpriteSwap : MonoBehaviour
{
    public Sprite presentSprite;
    public Sprite pastSprite;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        TimelineManager.OnTimelineChanged += HandleTimelineChanged;

        // apply current timeline immediately (so it’s correct on scene start)
        if (TimelineManager.Instance != null)
            HandleTimelineChanged(TimelineManager.Instance.currentTimeline);
    }

    private void OnDisable()
    {
        TimelineManager.OnTimelineChanged -= HandleTimelineChanged;
    }

    private void HandleTimelineChanged(Timeline t)
    {
        sr.sprite = (t == Timeline.Present) ? presentSprite : pastSprite;
    }
}
