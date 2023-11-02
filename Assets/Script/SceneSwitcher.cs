using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneSwitcher : MonoBehaviour
{
    public void Loadscene(string sceneName)
    {
       SceneManager.LoadScene(sceneName);
    }
}
