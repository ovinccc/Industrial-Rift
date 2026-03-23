using UnityEngine;

public class ConveyorBelt : MonoBehaviour
{
    public float pushSpeed = -5f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        bool conveyorActive = TimelineManager.Instance != null &&
                              TimelineManager.Instance.currentTimeline == Timeline.Past;

        // Handle player
        if (collision.CompareTag("Player"))
        {
            Character_movement player = collision.GetComponent<Character_movement>();
            if (player != null)
            {
                if (conveyorActive)
                {
                    player.SetConveyorPush(pushSpeed);
                    player.SetJumpEnabled(false);
                }
                else
                {
                    player.SetConveyorPush(0f);
                    player.SetJumpEnabled(true);
                }
            }
        }

        // Handle box
        if (collision.CompareTag("Box"))
        {
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                if (conveyorActive)
                {
                    rb.linearVelocity = new Vector2(pushSpeed, rb.linearVelocity.y);
                }
                else
                {
                    rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Handle player leaving
        if (collision.CompareTag("Player"))
        {
            Character_movement player = collision.GetComponent<Character_movement>();
            if (player != null)
            {
                player.SetConveyorPush(0f);
                player.SetJumpEnabled(true);
            }
        }

        // Handle box leaving
        if (collision.CompareTag("Box"))
        {
            

            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
            }
        }
    }
}