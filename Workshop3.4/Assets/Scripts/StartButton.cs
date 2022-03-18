using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] Color objectColor;
    [SerializeField] Color fadeColor;
    [SerializeField] string nextLevelName;
    [SerializeField] float delay;
    [SerializeField] float fadeTime;

    bool shouldFade;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        shouldFade = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
    }

    private void Update()
    {
        if (shouldFade)
        {
            ChangeColor();
        }
           
    }


    public void ButtonClicked()
    {
        Debug.Log("Clicked Button!");
        StartCoroutine(GoToLevelAfterDelay());
        shouldFade = true;
    }

    void ChangeColor()
    {
        float moveStep = fadeTime * Time.deltaTime;
        float lerpPoint = Mathf.MoveTowards(0, 1, moveStep);

        image.color = Color.Lerp(objectColor, fadeColor, lerpPoint);
    }

    IEnumerator GoToLevelAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        GoToNextLevel();

    }

    void GoToNextLevel()
    {
        SceneManager.LoadScene(nextLevelName);
    }
}
