using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private int level;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(level);
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
