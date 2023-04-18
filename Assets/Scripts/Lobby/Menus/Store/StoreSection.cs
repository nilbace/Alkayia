using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSection : MonoBehaviour
{
    [SerializeField]GameObject ItemListpopup;
    St_Popup st_Popup;
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
            st_Popup.setName("증폭구");
            break;

            case "Necklace":
            ItemListpopup.SetActive(true);
            st_Popup.setName("목걸이");
            break;

            case "Bracelet":
            ItemListpopup.SetActive(true);
            st_Popup.setName("팔찌");
            break;

            case "Earrings":
            ItemListpopup.SetActive(true);
            st_Popup.setName("귀걸이");
            break;

            case "Destroy":
            ItemListpopup.SetActive(true);
            st_Popup.setName("파괴석");
            break;

            case "Balance":
            ItemListpopup.SetActive(true);
            st_Popup.setName("조화석");
            break;



            default:
            break;
        }
    }

    public void closePopup()
    {
        ItemListpopup.SetActive(false);
    }
}
