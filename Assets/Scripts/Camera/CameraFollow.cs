using UnityEngine;
public class CameraFollowXClamp : MonoBehaviour 
{ 
    public Transform target; 
    public float smoothSpeed = 8f; 
    public float minX = -3.8f; 
    public float maxX = 3.8f; 

    float fixedY; 
    float fixedZ; 
    void Start() 
    { 
        fixedY = transform.position.y;
        fixedZ = transform.position.z; // usually -10
    } 
    void LateUpdate() 
    { 
        if (target == null) return; 
        float desiredX = target.position.x; // Clamp camera X
        float clampedX = Mathf.Clamp(desiredX, minX, maxX); 
        Vector3 targetPosition = new Vector3(clampedX, fixedY, fixedZ); 
        transform.position = Vector3.Lerp( 
            transform.position, 
            targetPosition, 
            smoothSpeed * Time.deltaTime 
            ); 
    } 
}