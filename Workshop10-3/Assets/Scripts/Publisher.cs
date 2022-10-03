using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Publisher : MonoBehaviour
{
    public delegate void PublishEvent();
    public static event PublishEvent Publish;

    int count = 0;

    [SerializeField] Text textToChange;

    public void PublishTheEvent()
    {
        if (Publish != null)
        {
            Publish();
        }
    }

    private void Update()
    {
        textToChange.text = $"You have caught {count}/50 cats";
        if (count > 50)
        {
            textToChange.text = "You win!";
        }
    }

    private void OnMouseDown()
    {
        PublishTheEvent();
        count++;
        
    }
}
