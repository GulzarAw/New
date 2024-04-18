using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoading : MonoBehaviour
{
    public static AsyncLoading _instance;
    public GameObject loadingScreen;
    public Image fillImage;
    public CanvasGroup canvasGroup;
    //public TextMeshProUGUI percentLoadedText;

    private void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        loadingScreen.SetActive(false);
        
    }

   
    public void LoadScene()
    {
        canvasGroup.alpha = 1f;
        loadingScreen.SetActive(true);
        StartCoroutine(LoadAsynchronously(LoadingData.sceneName));
    }

    IEnumerator LoadAsynchronously(string sceneName)
    {
        yield return new WaitForSecondsRealtime(1f);
        // SceneManager.LoadScene(sceneIndex);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .99f);
            //percentLoadedText.text = Mathf.Round(progress * 100) + "%";
            fillImage.fillAmount = progress;
            yield return null;
        }


        yield return StartCoroutine(FadeLoadingScreen(0, 1));
        //loadingScreen.SetActive(false);
    }

    IEnumerator FadeLoadingScreen(float targetValue, float duration)
    {
        float startValue = canvasGroup.alpha;
        float time = 0;

        while (time < duration)
        {
            canvasGroup.alpha = Mathf.Lerp(startValue, targetValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        canvasGroup.alpha = targetValue;

        loadingScreen.SetActive(false);
    }

   
}
