using UnityEngine;

public class TimePipe : MonoBehaviour
{
    public GameObject presentPipe;
    public GameObject pastPipe;

    private void OnEnable()
    {
        TimelineManager.OnTimelineChanged += HandleTimelineChanged;
    }

    private void OnDisable()
    {
        TimelineManager.OnTimelineChanged -= HandleTimelineChanged;
    }

    private void Start()
    {
        UpdateWall(TimelineManager.Instance.currentTimeline);
    }

    private void HandleTimelineChanged(Timeline newTimeline)
    {
        UpdateWall(newTimeline);
    }

    private void UpdateWall(Timeline timeline)
    {
        bool isPresent = timeline == Timeline.Present;

        presentPipe.SetActive(isPresent);
        pastPipe.SetActive(!isPresent);
    }
}