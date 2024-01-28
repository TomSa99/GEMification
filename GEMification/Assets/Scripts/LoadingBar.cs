using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingBar : MonoBehaviour {

    private RectTransform rectComponent;
    private Image imageComp;
    public GameObject loadingBar;
    public float speed = 0.0f;
    public GameObject answerResult;


    // Use this for initialization
    void Start () {
        rectComponent = GetComponent<RectTransform>();
        imageComp = rectComponent.GetComponent<Image>();
        imageComp.fillAmount = 0.0f;
    }

    void Update()
    {
        if (imageComp.fillAmount != 1f)
        {
            imageComp.fillAmount = imageComp.fillAmount + Time.deltaTime * speed;
            
        }
        else
        {
            loadingBar.SetActive(false);
            answerResult.SetActive(true);

        }
    }
}
