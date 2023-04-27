using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoreSection : MonoBehaviour
{
    public static StoreSection instance;
    [SerializeField]GameObject ItemListpopup;
    St_Popup st_Popup;
    int myMoney;
    [SerializeField] TMP_Text MyGoldText;
    private void Awake() {
        instance = this;
    }
    private void Start() {
        ItemListpopup.transform.localPosition = new Vector3(0,100f,0);
        ItemListpopup.SetActive(false);
        st_Popup=ItemListpopup.GetComponent<St_Popup>();
    }
    
    public void ClickStore(string section)
    {
        switch(section)
        {
            case "Amplifier":
            ItemListpopup.SetActive(true);
            st_Popup.Set_PopUp("증폭구", Define.ItemCategory.Amplifier);
            break;

            case "Necklace":
            ItemListpopup.SetActive(true);
            st_Popup.Set_PopUp("목걸이", Define.ItemCategory.Necklace);
            break;

            case "Bracelet":
            ItemListpopup.SetActive(true);
            st_Popup.Set_PopUp("팔찌", Define.ItemCategory.Bracelet);
            break;

            case "Earrings":
            ItemListpopup.SetActive(true);
            st_Popup.Set_PopUp("귀걸이", Define.ItemCategory.Earrings);
            break;

            case "Destroy":
            ItemListpopup.SetActive(true);
            st_Popup.Set_PopUp("파괴석", Define.ItemCategory.Destroy);
            break;

            case "Balance":
            ItemListpopup.SetActive(true);
            st_Popup.Set_PopUp("조화석", Define.ItemCategory.Balance);
            break;
        }
    }


    public void SetGoldText()
    {
        myMoney = UserData.instance.mySaveData.myMoney;
        MyGoldText.text = myMoney.ToString();
    }
}
