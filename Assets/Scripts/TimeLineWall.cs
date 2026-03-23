using UnityEngine;

public class TimelineWall : MonoBehaviour
{
    public GameObject presentWall;
    public GameObject pastWall;

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

        presentWall.SetActive(isPresent);
        pastWall.SetActive(!isPresent);
    }
}