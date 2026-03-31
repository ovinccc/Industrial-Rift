using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenuButtons : MonoBehaviour
{
    public Image fadeImage;
    public float fadeDuration = 1f;
    public string introSceneName = "IntroVideoScene";

    public void OnMouseDown()
    {
        StartCoroutine(FadeAndLoadIntro());
    }

    private IEnumerator FadeAndLoadIntro()
    {
        Color c = fadeImage.color;
        c.a = 0f;
        fadeImage.color = c;

        float time = 0f;

        while (time < fadeDuration)
        {
            float t = time / fadeDuration;
            c.a = Mathf.Lerp(0f, 1f, t);
            fadeImage.color = c;

            time += Time.deltaTime;
            yield return null;
        }

        c.a = 1f;
        fadeImage.color = c;

        SceneManager.LoadScene(introSceneName);
    }
}