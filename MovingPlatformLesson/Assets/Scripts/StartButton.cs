using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Color objectColor;
    [SerializeField] private Color fadeColor;
    [SerializeField] private float fadeTime;
    [SerializeField] string nextLevelName;

    private float fadeStart;
    private bool shouldFade;
    private Image image;

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        shouldFade = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (shouldFade)
        //{
        //    ChangeColor();
        //}
    }

    public void ButtonClicked()
    {
        Debug.Log("Clicked Button!");
        fadeStart = 0;
        shouldFade = true;
        ChangeColor();
        StartCoroutine(StartLevelAfterDelay());
    }

    void ChangeColor()
    {
        if (fadeStart < fadeTime)
        {
            fadeStart += Time.deltaTime;

            image.color = Color.Lerp(objectColor, fadeColor, fadeStart/fadeTime);
        }
    }

    void GoToNextLevel()
    {
        Debug.Log("Go to level " + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
    }

    IEnumerator StartLevelAfterDelay()
    {
        yield return new WaitForSeconds(2);
        GoToNextLevel();

    }
}
