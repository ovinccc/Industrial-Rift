using UnityEngine;

public class LevelEndTrigger : MonoBehaviour
{
    public WinScreen winScreen;

    private void Awake()
    {
        if (winScreen == null)
        {
            winScreen = FindFirstObjectByType<WinScreen>();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;

        winScreen.ShowWin();
       

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}