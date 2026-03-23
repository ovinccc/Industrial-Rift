using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Level1");
    }
}
