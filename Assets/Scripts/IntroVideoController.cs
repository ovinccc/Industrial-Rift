using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class IntroVideoController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public Image fadeImage;
    public float fadeDuration = 1f;
    public string nextSceneName = "Level1";

    private void Start()
    {
        StartCoroutine(PlayIntroSequence());
    }

    private IEnumerator PlayIntroSequence()
    {
        // Start fully black
        Color c = fadeImage.color;
        c.a = 1f;
        fadeImage.color = c;

        // Small delay just in case
        yield return null;

        // Fade from black to visible video
        yield return StartCoroutine(Fade(1f, 0f));

        // Play video
        videoPlayer.Play();

        // Wait until video finishes
        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        // Fade back to black
        yield return StartCoroutine(Fade(0f, 1f));

        // Load first level
        SceneManager.LoadScene(nextSceneName);
    }

    private IEnumerator Fade(float startAlpha, float endAlpha)
    {
        float time = 0f;
        Color c = fadeImage.color;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            c.a = Mathf.Lerp(startAlpha, endAlpha, t);
            fadeImage.color = c;

            time += Time.deltaTime;
            yield return null;
        }

        c.a = endAlpha;
        fadeImage.color = c;
    }
}
