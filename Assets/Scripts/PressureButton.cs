using UnityEngine;
using System.Collections.Generic;

public class PressureButton : MonoBehaviour
{
    public MovingDoor door;

    private HashSet<Collider2D> pressingObjects = new HashSet<Collider2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            pressingObjects.Add(collision);
            UpdateDoor();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Box"))
        {
            pressingObjects.Remove(collision);
            UpdateDoor();
        }
    }

    private void UpdateDoor()
    {
        if (door != null)
        {
            door.SetOpen(pressingObjects.Count > 0);
        }
    }
}
