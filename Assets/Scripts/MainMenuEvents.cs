using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuEvents : MonoBehaviour
{
    public  GameObject loadSceneScreen;
    private UIDocument _document;

    private Button _button;


    private void Awake()
    {

        _document = GetComponent<UIDocument>();

        _button = _document.rootVisualElement.Q("Start") as Button;

        _button.RegisterCallback<ClickEvent>(OnPlayGameClick);
    }


    private void OnDisable()
    {
        _button.UnregisterCallback<ClickEvent>(OnPlayGameClick);
    }

    private void OnPlayGameClick(ClickEvent evt)
    {
        Debug.Log("You Pressed The Start Button");
        loadSceneScreen.GetComponent<LoadingScene>().LoadScene(1);
    }
}
