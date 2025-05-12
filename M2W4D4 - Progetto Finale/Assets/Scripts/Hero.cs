using UnityEngine;

[System.Serializable]
public class Hero
{
    [SerializeField] private string name;
    [SerializeField] private int hp;
    [SerializeField] private Stats baseStats;
    [SerializeField] private ELEMENT resistance;
    [SerializeField] private ELEMENT weakness;
    [SerializeField] private Weapon weapon;

    public Hero(string name, int hp, Stats baseStats, ELEMENT resistance, ELEMENT weakness, Weapon weapon)
    {
        this.name = name;
        this.hp = hp;
        this.baseStats = baseStats;
        this.resistance = resistance;
        this.weakness = weakness;
        this.weapon = weapon;
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    public Stats BaseStats
    {
        get { return baseStats; }
        set { baseStats = value; }
    }

    public ELEMENT Resistance
    {
        get { return resistance; }
        set { resistance = value; }
    }

    public ELEMENT Weakness
    {
        get { return weakness; }
        set { weakness = value; }
    }

    public Weapon Weapon
    {
        get { return weapon; }
        set { weapon = value; }
    }

    public void AddHp(int amount)
    {
        hp += amount;
    }

    public void TakeDamage(int damage)
    {
        AddHp(-damage);
    }

    public bool IsAlive()
    {
        return hp > 0;
    }
}
