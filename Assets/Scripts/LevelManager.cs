using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneAsync(sceneName));
    }

    private IEnumerator LoadSceneAsync(string sceneName)
    {
        // Play transition animation if necessary
        if (animator != null)
        {
            animator.SetTrigger("StartTransition");
            yield return new WaitForSeconds(1f); // Adjust delay for animation duration
        }

        // Load the scene asynchronously
        AsyncOperation operation = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }

        // End transition if necessary
        if (animator != null)
        {
            animator.SetTrigger("EndTransition");
        }
    }
}
