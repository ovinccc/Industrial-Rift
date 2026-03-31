using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using System.Collections;

public class LevelTransitionController : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public CanvasGroup fadeCanvasGroup;
    public GameObject continueText;
    public float fadeDuration = 1f;

    private bool waitingForSpace = false;

    private void Start()
    {
        StartCoroutine(RunSequence());
    }

    private void Update()
    {
        if (waitingForSpace && Input.GetKeyDown(KeyCode.Space))
        {
            waitingForSpace = false;

            if (continueText != null)
            {
                continueText.SetActive(false);
            }

            StartCoroutine(FadeAndLoadNextScene());
        }
    }

    private IEnumerator RunSequence()
    {
        if (continueText != null)
        {
            continueText.SetActive(false);
        }

        if (fadeCanvasGroup != null)
        {
            fadeCanvasGroup.alpha = 0f;
        }

        if (LevelTransitionData.firstClip != null)
        {
            videoPlayer.clip = LevelTransitionData.firstClip;
            videoPlayer.Prepare();

            while (!videoPlayer.isPrepared)
            {
                yield return null;
            }

            videoPlayer.Play();
        }

        while (videoPlayer.isPlaying)
        {
            yield return null;
        }

        if (continueText != null)
        {
            continueText.SetActive(true);
        }

        waitingForSpace = true;
    }

    private IEnumerator FadeAndLoadNextScene()
    {
        if (fadeCanvasGroup != null)
        {
            yield return StartCoroutine(Fade(0f, 1f));
        }

        SceneManager.LoadScene(LevelTransitionData.nextSceneName);
    }

    private IEnumerator Fade(float start, float end)
    {
        float time = 0f;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            fadeCanvasGroup.alpha = Mathf.Lerp(start, end, t);
            time += Time.deltaTime;
            yield return null;
        }

        fadeCanvasGroup.alpha = end;
    }
}