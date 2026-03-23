using UnityEngine;

public class BobbingEffect : MonoBehaviour
{
    public float amplitude = 0.25f;
    public float frequency = 2f;

    private Vector3 startPos;
    void Start()
    {
        startPos = transform.position;
    }

    
    void Update()
    {
        float yOffset = Mathf.Sin(Time.time * frequency) * amplitude;
        transform.position = new Vector3(startPos.x, startPos.y + yOffset, startPos.z);
    }
}
