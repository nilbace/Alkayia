using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreSection : MonoBehaviour
{
    [SerializeField]GameObject ItemListpopup;
    private void Start() {
        ItemListpopup.transform.localPosition = new Vector3(0,100f,0);
        ItemListpopup.SetActive(false);
    }
    
    public void ClickStore(string section)
    {
        switch(section)
        {
            case "Weapon":
            ItemListpopup.SetActive(true);
            //section 넘겨서 정렬
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
