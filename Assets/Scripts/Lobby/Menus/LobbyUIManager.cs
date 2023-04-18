using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class LobbyUIManager : MonoBehaviour
{
    [Header("BackgroundImage")]
    [SerializeField] float backImageMoveTime;
    public RectTransform BackgroundImage;
    [Header("SectionButtons")]

    public Button[] sectionButtons;
    [SerializeField] float ScrollDownPosition;
    [SerializeField] float ScrollUpPosition;
    public Image RequestBoard;
    public Transform ContentParent;
    public GameObject QuestList;
    public GameObject Tree;
    public List<GameObject> QuestLists = new List<GameObject>();
    [SerializeField] Ease EaseStatus;
    [SerializeField] float moveTime;
    [SerializeField] float elasticScale;
    [SerializeField] float periodScale;
    void Start()
    {
        CreateQuestList();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            RequestBoard.rectTransform.DOAnchorPosY(ScrollUpPosition, moveTime).SetEase(EaseStatus, elasticScale, periodScale);
            StopAllCoroutines();
            StartCoroutine(UnQuestBoardCall());
        }
    }

    void CreateQuestList()
    {
        for(int i = UserData.instance.mySaveData.int_conqueredMonster+1; i >0 ; i--)
            {
                GameObject listObject = Instantiate(QuestList, Vector3.up, Quaternion.identity, ContentParent);
                listObject.GetComponent<QuestList>().SetQuest(i);
            }
    }

    public void PressUIButtion(int index)
    {
        BackgroundImage.DOAnchorPosX(index*(-1080f), backImageMoveTime).SetEase(Ease.OutCirc);
        for(int i = 0; i<5;i++)
        {
            sectionButtons[i].interactable = i==index ? false : true;
        }
    }

    public void RequestButton()
    {
        RequestBoard.rectTransform.DOAnchorPosY(ScrollDownPosition, moveTime).SetEase(EaseStatus, elasticScale, periodScale);
        StopAllCoroutines();
        StartCoroutine(QuestBoardCall());
    }


    IEnumerator QuestBoardCall()
    {
        yield return new WaitForSeconds(moveTime);
        foreach(GameObject quest in QuestLists)
        {
            quest.transform.DOLocalMoveX(0f ,moveTime).SetEase(EaseStatus, elasticScale, periodScale);
            yield return new WaitForSeconds(0.2f);
        }
    }

    IEnumerator UnQuestBoardCall()
    {
        yield return new WaitForSeconds(0.01f);
        foreach(GameObject quest in QuestLists)
        {
            quest.transform.DOLocalMoveX(-1080f ,0.03f).SetEase(EaseStatus, elasticScale, periodScale);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
