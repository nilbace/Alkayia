using UnityEngine;
public class Define
{
    public enum AlkayiaSkill{
        IceNeedle, 
        IceShield, 
        IceSpear, 
        IceThorn, 
        IceShower, 
        IceStorm, 
        IceSword, 
        IceHammer, 
        IceBreath,
        MaxCount
    }

    public enum ItemCategory{Amplifier, Necklace, Bracelet, Earrings, Destroy, Balance}

    [System.Serializable] // 장비 아이템들
    public class Item{
    public Sprite image;
    public string ItemName;
    public int ItemIndex;
    public int itemStat;
    public string itemInfo;
    public ItemCategory itemCategory;

        public Item(string itemName, int itemIndex, int itemStat, string itemInfo, ItemCategory itemCategory)
        {
            ItemName = itemName;
            ItemIndex = itemIndex;
            this.itemStat = itemStat;
            this.itemInfo = itemInfo;
            this.itemCategory = itemCategory;
            string temp = "Temps/Acc/" + itemName;
            this.image = Resources.Load<Sprite>(temp);
        }
    }
}
