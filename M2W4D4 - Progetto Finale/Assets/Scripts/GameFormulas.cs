using UnityEngine;

public static class GameFormulas
{

    public static bool HasElementAdvantage(ELEMENT attackElement, ELEMENT weakness)
    {
        return attackElement == weakness;
    }

    public static bool HasElementDisadvantage(ELEMENT attackElement, ELEMENT resistance)
    {
        return attackElement == resistance;
    }

    public static float EvaluateElementalModifier(ELEMENT attackElement, ELEMENT resistance, ELEMENT weakness)
    {
        if (HasElementAdvantage(attackElement, weakness))
        {
            Debug.Log("HAS ADVANTAGE");
            return 1.5f;
        }
        else if (HasElementDisadvantage(attackElement, resistance))
        {
            Debug.Log("HAS DISADVANTAGE");
            return 0.5f;
        }
        else
        {
            return 1f;
        }
    }

    public static bool HasHit(int hitChance, int evaValue)
    {
        int roll = Random.Range(0, 101); // 0-100 inclusi
        return roll < (hitChance - evaValue);  // Se il roll è minore della differenza tra hitChance e evasione, colpisce
    }

    public static bool IsCrit(int critValue)
    {
        int roll = Random.Range(0, 101);
        return roll < critValue;
    }

    public static int CalculateDamage(Hero attacker, Hero defender)
    {
        Stats atkStats = Stats.Sum(attacker.BaseStats, attacker.Weapon.BonusStats);
        Stats defStats = Stats.Sum(defender.BaseStats, defender.Weapon.BonusStats);

        int baseDamage = 0;

        if (attacker.Weapon.DmgType == Weapon.DAMAGE_TYPE.PHYSICAL)  // Controllo se é un arma di tipo fisica
        {
            baseDamage = atkStats.atk - defStats.def;
        }
        else // Se non é un'arma fisica, é per forza magica	(come la Roma)
        {
            baseDamage = atkStats.atk - defStats.res;
        }

        if (baseDamage < 0)
            baseDamage = 0;

        // Controllo se é un colpo critico
        if (IsCrit(atkStats.crt))
        {
            Debug.Log("CRITICAL HIT!");
            baseDamage = Mathf.RoundToInt(baseDamage * 1.5f);
        }

        // Aggiungo il modificatore elementale
        float elemModifier = EvaluateElementalModifier(attacker.Weapon.Elem, defender.Resistance, defender.Weakness);
        baseDamage = Mathf.RoundToInt(baseDamage * elemModifier);

        return baseDamage;
    }
}
