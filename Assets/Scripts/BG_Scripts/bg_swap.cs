using UnityEngine;
using System.Collections;

public class BackgroundSwap : MonoBehaviour
{
    public Sprite background1; //present
    public Sprite background2; //past

    public TimelineTransition transitionEffect;

    private SpriteRenderer sr;
    private bool isBackground1 = true;

    private bool canSwapTimeline = false;
    private bool isSwapping = false;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        if (TimelineManager.Instance.currentTimeline == Timeline.Present)
        {
            sr.sprite = background1;
            isBackground1 = true;
        }
        else
        {
            sr.sprite = background2;
            isBackground1 = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canSwapTimeline && !isSwapping)
        {
            StartCoroutine(SwapTimelineRoutine());
        }

    }

    IEnumerator SwapTimelineRoutine()
    {
        isSwapping = true;

        if (transitionEffect != null)
        {
            transitionEffect.PlayTransition();
        }

        yield return new WaitForSeconds(0.8f);

        isBackground1 = !isBackground1;

        if (isBackground1)
        {
            sr.sprite = background1;
            TimelineManager.Instance.SetTimeline(Timeline.Present);
        }
        else
        {
            sr.sprite = background2;
            TimelineManager.Instance.SetTimeline(Timeline.Past);
        }

        yield return new WaitForSeconds(0.4f);

        isSwapping = false;
    }


    public void SetSwapEnabled(bool enabled)
    {
        canSwapTimeline = enabled;
    }
}
