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

    [System.Serializable]
    public class Monster{
    public string name;
    public int Monsterindex;
    public int attackPower;
    public int attackTerm;
    public int HP;
    public string boardExplanation;
    public string AlkayiaTip;

    public Monster(string name = "몬스터!", int attackPower = 5, int attackTerm = 5, int hP = 30, string boardExplanation = "이게 보이면 안된다!",int monindex = 0, string _alktip = "")
        {
            this.name = name;
            this.attackPower = attackPower;
            this.attackTerm = attackTerm;
            HP = hP;
            this.boardExplanation = boardExplanation;
            this.Monsterindex = monindex;
            this.AlkayiaTip = _alktip;
        }
    }

    public enum Scene
    {
        Unknown,
        Login,
        Lobby,
        BattleScene,
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
        Lydia , Alkayia, Nadira, Lyra, 
    };
}
