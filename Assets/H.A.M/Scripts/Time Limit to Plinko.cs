using UnityEngine;
using UnityEngine.SceneManagement;

public class TimerToPlinko : MonoBehaviour
{
    public float timeLimit = 20f;

    private void Start()
    {
        Invoke(nameof(LoadPlinko), timeLimit);
    }

    private void LoadPlinko()
    {
        SceneManager.LoadScene("Plinko");
    }
}
