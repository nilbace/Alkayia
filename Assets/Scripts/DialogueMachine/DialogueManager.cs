using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    int index = 0;
    public Image Portrait;
    public TMP_Text nameTMP;
    public TMP_Text speechTMP;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            ShowNext();
            index++;
        }
    }

    void ShowNext()
    {
        Portrait.sprite = ParsingMachine.DiaList[index].Portrait;
        nameTMP.text    = ParsingMachine.DiaList[index].name;
        speechTMP.text  = ParsingMachine.DiaList[index].speech;
    }
}
