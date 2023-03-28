using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LobbyUIManager : MonoBehaviour
{
    [SerializeField] float speed;
    public RectTransform BackgroundImage;
    public Button[] sectionButtons;
    void Start()
    {
        sectionButtons[2].interactable = false;
    }

    void Update()
    {
        
    }

    public void PressUIButtion(int index)
    {
        LeftTOIndex(index);
        for(int i = 0; i<5;i++)
        {
            sectionButtons[i].interactable = i==index ? false : true;
        }
    }

    void LeftTOIndex(int index)
    {
        //StopAllCoroutines();
        //StartCoroutine(moveto(index*(-1080)));
        BackgroundImage.transform.DOMoveX
    }
    
    IEnumerator moveto(float targetX)
    {
        while (Mathf.Abs(BackgroundImage.localPosition.x - targetX) > 1f)
        {
            BackgroundImage.localPosition = Vector3.Lerp(BackgroundImage.localPosition, new Vector3(targetX, BackgroundImage.localPosition.y, transform.position.z), speed * Time.deltaTime);
            yield return null;
        }
        BackgroundImage.localPosition = new Vector3(targetX, BackgroundImage.localPosition.y, BackgroundImage.localPosition.z);
    
    }

}
