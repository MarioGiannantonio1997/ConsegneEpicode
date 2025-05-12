using UnityEngine;

[System.Serializable]
public class Weapon
{
    public enum DAMAGE_TYPE { PHYSICAL, MAGICAL }

    [SerializeField] private string name;
    [SerializeField] private DAMAGE_TYPE dmgType;
    [SerializeField] private ELEMENT elem;
    [SerializeField] private Stats bonusStats;

    public Weapon(string name, DAMAGE_TYPE dmgType, ELEMENT elem, Stats bonusStats)
    {
        this.name = name;
        this.dmgType = dmgType;
        this.elem = elem;
        this.bonusStats = bonusStats;
    }

    // Getter e Setter 
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public DAMAGE_TYPE DmgType
    {
        get { return dmgType; }
        set { dmgType = value; }
    }

    public ELEMENT Elem
    {
        get { return elem; }
        set { elem = value; }
    }

    public Stats BonusStats
    {
        get { return bonusStats; }
        set { bonusStats = value; }
    }

}

