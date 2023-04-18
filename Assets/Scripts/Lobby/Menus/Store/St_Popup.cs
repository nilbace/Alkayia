using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class St_Popup : MonoBehaviour
{
    [SerializeField] TMP_Text CateName;
    [SerializeField] GameObject Item;
    [SerializeField] GameObject content;
    public List<GameObject> itemsOnPopup;
    public void setName(string name)
    {
        CateName.text = name;
    } 
}
