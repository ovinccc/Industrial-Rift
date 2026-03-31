using UnityEngine;

public class TimePortal : MonoBehaviour
{
    public BackgroundSwap backgroundSwap;
    public SpriteRenderer portalOutlineRenderer;

    private void Start()
    {
        if (portalOutlineRenderer != null)
        {
            portalOutlineRenderer.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            backgroundSwap.SetSwapEnabled(true);

            if (portalOutlineRenderer != null)
            {
                portalOutlineRenderer.enabled = true;
            }
                
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            backgroundSwap.SetSwapEnabled(false);

            if (portalOutlineRenderer != null)
            {
                portalOutlineRenderer.enabled = false;
            }
        }
    }
}