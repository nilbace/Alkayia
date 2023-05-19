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

    [System.Serializable]
    public class SkillVersionData{
        public int skillIndex;
        public string skillName;
        public bool hasProperty;
        public bool hasFirstProperty;

        public SkillVersionData(){
            this.skillIndex = -1;
            this.skillName = "Nothing";
            this.hasProperty = false;
            this.hasFirstProperty = true;
        }
    }

[System.Serializable]
    public class MyEquipItems{
        public Item EquipedAmplifier;
        public Item EquipedNecklace;
        public Item EquipedBracelet;
        public Item EquipedEarrings;
        public Item EquipedDestroy;
        public Item EquipedBalance;
        public BoardSize myboardSize = BoardSize.Size4_4;

        public MyEquipItems()
        {
            EquipedAmplifier=null;
            EquipedBalance=null;
            EquipedBracelet=null;
            EquipedDestroy=null;
            EquipedEarrings=null;
            EquipedNecklace=null;
        }
    }

    public enum BoardSize{
        Size4_4, Size5_5, Size6_6
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        Game,
    }

    public enum Sound
    {
        Bgm,
        Effect,
        MaxCount,
    }
    public enum UIEvent
    {
        Click,
        Drag,
        
    }
    public enum MouseEvent{
        Press,
        Click,
    }
    public enum CameraMode{
        QuaterView,
    }

    public enum CharName {
        Alkayia, Nadira, Lyra, Siro
    };
}
