using UnityEngine;

public class PipeBoxSpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    public GameObject boxPrefab;
    public Transform spawnPoint;
    public KeyCode spawnKey = KeyCode.E;

    [Header("Timeline Gate")]
    public Timeline allowedTimeline = Timeline.Past;


    private bool playerNearby = false;
    private GameObject currentBox;
    void Update()
    {

        if (Input.GetKeyDown(spawnKey) && TimelineManager.Instance.currentTimeline == allowedTimeline && playerNearby)
        {
            RespawnBox();
        }
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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
