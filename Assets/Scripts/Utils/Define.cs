using UnityEngine;
public class Define
{

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

    public class LydiaStat{
        [SerializeField]
        int _attackPower;
        public int AttackPower { get{return _attackPower;} set{ _attackPower = value;}}

        [SerializeField]
        int _hp;
        public int HP {get { return _hp;} set { _hp = value;}}

        [SerializeField]
        int _attackTerm;
        public int AttackTerm { get{return _attackTerm;} set{ _attackTerm = value;}}

        [SerializeField]
        BoardSize _myboardsize;
        public BoardSize MyBoardSize { get { return _myboardsize;} set{ _myboardsize = value;}}

        [SerializeField]
        int _maxNum;
        public int MaxNum { get{return _maxNum;} set{ _maxNum = value;}}
    }

    public enum BoardSize{
        Size4_4, Size5_5, Size6_6
    }

    [System.Serializable]
    public class Monster{
    public string MonName;
    public int Monsterindex;
    public int attackPower;
    public float attackTerm;
    public int HP;
    public string boardExplanation;
    public string AlkayiaTip;
    public Sprite image;

    public Monster(string name = "몬스터!", int attackPower = 5, float attackTerm = 5, int hP = 30, string boardExplanation = "이게 보이면 안된다!",int monindex = 0, string _alktip = "")
        {
            this.MonName = name;
            this.attackPower = attackPower;
            this.attackTerm = attackTerm;
            HP = hP;
            this.boardExplanation = boardExplanation;
            this.Monsterindex = monindex;
            this.AlkayiaTip = _alktip;
            string temp = "Temps/Mon/" + MonName;
            this.image = Resources.Load<Sprite>(temp);
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
    }

    public enum EffectName{
        Blaze,
        

    }

    public class Effect{

    }

    public class Skill{
        bool _targetIsMe;
        bool _isAttackSkill;
        bool _isBuffSkill;
        bool _isDebuffSkill;
        bool sdf;
    }
}
