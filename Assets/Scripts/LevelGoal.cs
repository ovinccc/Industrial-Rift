using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EnvelopePickup : MonoBehaviour
{
    public string transitionSceneName = "LevelTransitionScene1";
    public string nextLevelSceneName = "Level2";
    public VideoClip firstClip;

    private bool pickedUp = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (pickedUp) return;

        if (collision.CompareTag("Player"))
        {
            pickedUp = true;

            LevelTransitionData.nextSceneName = nextLevelSceneName;
            LevelTransitionData.firstClip = firstClip;

            SceneManager.LoadScene(transitionSceneName);
        }
    }
}