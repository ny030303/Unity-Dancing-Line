using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadingSceneManager : MonoBehaviour
{
    public static string nextScene;
    public GameObject canvas;
    public Slider slider;
    //public ProgressBarScript progressBar;
    public float FillSpeed = 0.5f;
    private float targetProgress = 0;

    private void Awake()
    {
        canvas.SetActive(false);
    }

    private void Start()
    {
        GameObject.Find("Canvas");
    }

    private void Update()
    {
        if (slider.value < targetProgress)
            slider.value += FillSpeed * Time.deltaTime;
    }
    public void LoadScene(string sceneName)
    {
        nextScene = sceneName;
        canvas.SetActive(true);
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation op = SceneManager.LoadSceneAsync(nextScene);
        op.allowSceneActivation = false;
        float timer = 0.0f;
        while (!op.isDone)
        {
            yield return null;
            timer += Time.deltaTime;
            if (op.progress < 0.9f)
            {
                targetProgress = slider.value + op.progress;
                if (slider.value >= op.progress)
                {
                    timer = 0f;
                }
            }
            else
            {
                targetProgress = slider.value + op.progress;
                if (slider.value == 1.0f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
        }
    }
}