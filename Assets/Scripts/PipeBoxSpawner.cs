using UnityEngine;
using System.Collections;

public class PipeBoxSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject boxPrefab;
    public Transform spawnPoint;
    public KeyCode spawnKey = KeyCode.E;

    [Header("Timeline Gate")]
    public Timeline allowedTimeline = Timeline.Past;

    [Header("Lever Animation")]
    public Animator leverAnimator;
    public string pullTriggerName = "Pull";
    public string idleStateName = "idle";
    public float animationDuration = 0.5f;

    private bool playerNearby = false;
    private bool isAnimating = false;
    private GameObject currentBox;

    public SpriteRenderer leverOutlineRenderer;

    void Start()
    {
        if (leverAnimator != null)
        {
            leverAnimator.ResetTrigger(pullTriggerName);
            leverAnimator.Play(idleStateName, 0, 0f);
        }

        UpdateOutline();
    }
    void Update()
    {

        if (Input.GetKeyDown(spawnKey) && !isAnimating && TimelineManager.Instance != null && TimelineManager.Instance.currentTimeline == allowedTimeline && playerNearby)
        {
            StartCoroutine(ActivateLever());
        }

        UpdateOutline();
    }
    private IEnumerator ActivateLever()
    {
        isAnimating = true;
        UpdateOutline();

        if (leverAnimator != null)
        {
            leverAnimator.ResetTrigger(pullTriggerName);
            leverAnimator.SetTrigger(pullTriggerName);
        }

        RespawnBox();

        yield return new WaitForSeconds(animationDuration);

        isAnimating = false;
        UpdateOutline();
    }
    void RespawnBox()
    {
        if (currentBox != null)
        {
            Destroy(currentBox);
        }

        currentBox = Instantiate(boxPrefab, spawnPoint.position, Quaternion.identity);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = true;
        }
        UpdateOutline();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;

            UpdateOutline();
        }
    }

    private void UpdateOutline()
    {
        if (leverOutlineRenderer != null)
        {
            bool inPastTimeline = TimelineManager.Instance != null &&
                                  TimelineManager.Instance.currentTimeline == allowedTimeline;

            leverOutlineRenderer.enabled = playerNearby && inPastTimeline && !isAnimating;
        }
    }
}
