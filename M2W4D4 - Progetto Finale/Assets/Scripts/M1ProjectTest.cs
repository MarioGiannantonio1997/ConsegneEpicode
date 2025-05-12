using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    [SerializeField] private Hero a;
    [SerializeField] private Hero b;

    private bool combatEnded = false;

    private void Update()
    {
        if (!combatEnded)
        {
            HandleCombatRound(); 
        }
    }

    private void HandleCombatRound()
    {
        // Se un personaggio è morto, il metodo ritorna
        if (!a.IsAlive())
        {
            Debug.Log($"{b.Name} wins!"); 
            combatEnded = true;
            return;
        }

        if (!b.IsAlive())
        {
            Debug.Log($"{a.Name} wins!");
            combatEnded = true;
            return;
        }

        // Calcolo velocità (spd base + bonus arma)
        int aSpeed = a.BaseStats.spd + a.Weapon.BonusStats.spd;
        int bSpeed = b.BaseStats.spd + b.Weapon.BonusStats.spd;

        Hero first = aSpeed >= bSpeed ? a : b;
        Hero second = (first == a) ? b : a;

        // Stampa chi attacca e chi si difende
        Debug.Log($"ROUND START: {first.Name} attacks {second.Name}");

        SimulateAttack(first, second); // ✅ Attacco principale

        if (second.IsAlive())
        {
            // Se il difensore è vivo, contrattacca
            Debug.Log($"{second.Name} counter-attacks {first.Name}");
            SimulateAttack(second, first);
        }

        // Controllo vincitore finale (dopo entrambi gli attacchi)
        if (!a.IsAlive())
        {
            Debug.Log($"{b.Name} wins!");
            combatEnded = true;
        }
        else if (!b.IsAlive())
        {
            Debug.Log($"{a.Name} wins!");
            combatEnded = true;
        }
    }

    private void SimulateAttack(Hero attacker, Hero defender)
    {
        Stats atkStats = Stats.Sum(attacker.BaseStats, attacker.Weapon.BonusStats);
        Stats defStats = Stats.Sum(defender.BaseStats, defender.Weapon.BonusStats);

        Debug.Log($"{attacker.Name} attacks {defender.Name}");

        // Si calcola solo se colpisce
        if (!GameFormulas.HasHit(atkStats.aim, defStats.eva))
        {   
            Debug.Log("Attack missed!");
            return;
        }

        //  Calcolo del danno (include critico e modificatori elementali)
        int damage = GameFormulas.CalculateDamage(attacker, defender);

        //  Il danno viene inflitto
        defender.TakeDamage(damage);

        // Stampa HP residui
        Debug.Log($"{defender.Name} takes {damage} damage. Remaining HP: {defender.Hp}");
    }

    // Funzione creata durante lo sviluppo per testare i personaggi più velocemente e dinamicamente
       private Hero CreateRandomHero(string name, string weaponName)
    {
        int R(int min, int max) => Random.Range(min, max + 1);
        Stats RandomStats() => new Stats(R(5, 20), R(5, 20), R(5, 20), R(5, 20), R(5, 20), R(50, 100), R(5, 20));
        ELEMENT RandomElem() => (ELEMENT)Random.Range(1, 4);

        ELEMENT resistance = RandomElem();
        ELEMENT weakness;
        do { weakness = RandomElem(); } while (weakness == resistance);

        Weapon weapon = new Weapon(
            weaponName,
            (Random.value > 0.5f) ? Weapon.DAMAGE_TYPE.PHYSICAL : Weapon.DAMAGE_TYPE.MAGICAL,
            RandomElem(),
            RandomStats()
        );

        //return new Hero(name, R(60, 100), RandomStats(), resistance, weakness, weapon);
        return new Hero(name, 200, RandomStats(), resistance, weakness, weapon); // Per testing forzo più HP ai personaggi per far fare più rounds.

    }
}
// 