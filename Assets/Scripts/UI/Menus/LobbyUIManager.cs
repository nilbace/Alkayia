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
    public Image RequestBoard;
    public GameObject QuestListParent;
    public List<GameObject> QuestLists = new List<GameObject>();
    [SerializeField] Ease EaseStatus;
    [SerializeField] float moveTime;
    [SerializeField] float elasticScale;
    [SerializeField] float periodScale;
    void Start()
    {
        sectionButtons[2].interactable = false;
        QuestLists.Add(QuestListParent.transform.GetChild(0).gameObject);
        QuestLists.Add(QuestListParent.transform.GetChild(1).gameObject);
        QuestLists.Add(QuestListParent.transform.GetChild(2).gameObject);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            RequestBoard.rectTransform.DOAnchorPosY(1300f, moveTime).SetEase(EaseStatus, elasticScale, periodScale);
            StopAllCoroutines();
            StartCoroutine(UnQuestCall());
        }
    }

    public void PressUIButtion(int index)
    {
        LeftTOIndex(index);
        for(int i = 0; i<5;i++)
        {
            sectionButtons[i].interactable = i==index ? false : true;
        }
    }

    public void RequestButton()
    {
        RequestBoard.rectTransform.DOAnchorPosY(-507f, moveTime).SetEase(EaseStatus, elasticScale, periodScale);
        StopAllCoroutines();
        StartCoroutine(QuestCall());
    }


    void LeftTOIndex(int index)
    {
        StopAllCoroutines();
        StartCoroutine(moveto(index*(-1080)));
        //BackgroundImage.DOAnchorPosX(index*(-1080), moveTime).SetEase(EaseStatus, amplitude: elasticScale, period: periodScale);
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

    IEnumerator QuestCall()
    {
        yield return new WaitForSeconds(moveTime);
        foreach(GameObject quest in QuestLists)
        {
            quest.transform.DOLocalMoveX(0f ,moveTime).SetEase(EaseStatus, elasticScale, periodScale);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator UnQuestCall()
    {
        yield return new WaitForSeconds(0.01f);
        foreach(GameObject quest in QuestLists)
        {
            quest.transform.DOLocalMoveX(-1080f ,0.03f).SetEase(EaseStatus, elasticScale, periodScale);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
