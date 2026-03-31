using UnityEngine;

public class MovingDoor : MonoBehaviour
{
    public Vector3 closedPosition;
    public Vector3 openPosition;
    public float moveSpeed = 2f;

    private bool isOpen = false;

    private void Start()
    {
        transform.position = closedPosition;
    }

    private void Update()
    {
        Vector3 target = isOpen ? openPosition : closedPosition;
        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
    }

    public void SetOpen(bool open)
    {
        isOpen = open;
    }
}
