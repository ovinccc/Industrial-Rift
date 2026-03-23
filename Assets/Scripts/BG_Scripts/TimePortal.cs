using UnityEngine;

public class TimePortal : MonoBehaviour
{
    public BackgroundSwap backgroundSwap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            backgroundSwap.SetSwapEnabled(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            backgroundSwap.SetSwapEnabled(false);
        }
    }
}