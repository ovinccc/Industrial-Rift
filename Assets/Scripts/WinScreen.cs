using UnityEngine;

public class WinScreen : MonoBehaviour
{
    public GameObject winScreen;   // drag WinScreen here in Inspector

    public void ShowWin()
    {
        winScreen.SetActive(true);

        Time.timeScale = 10f;
    }
}