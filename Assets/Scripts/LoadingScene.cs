using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class LoadingScene : MonoBehaviour
{

    private UIDocument _document;

    private ProgressBar _progressBar;
    
    
    void Awake()
    {
        _document = GetComponent<UIDocument>();

        _progressBar = _document.rootVisualElement.Q("ProgressBar") as ProgressBar;

        
    }


    void Update()
    {
        
    }

    public void LoadScene (int sceneId)
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);



        _document.sortingOrder = 1;


        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress/0.9f);

            _progressBar.value = progressValue;

            yield return null;
        }
    }
}
