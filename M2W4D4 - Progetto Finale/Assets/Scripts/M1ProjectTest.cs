using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    private Hero a;
    private Hero b;
    private bool combatEnded = false;

    private float roundTimer = 0f;
    private float roundInterval = 1f; // 1 secondo tra un round e l’altro

    private void Start()
    {
        InitRandomHeroes();
    }

    private void Update()
    {
        if (combatEnded) return;

        roundTimer += Time.deltaTime;

        if (roundTimer >= roundInterval)
        {
            HandleCombatRound();
            roundTimer = 0f;
        }
    }

    private void HandleCombatRound()
    {
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

        int aSpeed = a.BaseStats.spd + a.Weapon.BonusStats.spd;
        int bSpeed = b.BaseStats.spd + b.Weapon.BonusStats.spd;

        Hero first = aSpeed >= bSpeed ? a : b;
        Hero second = (first == a) ? b : a;

        Debug.Log($"ROUND START: {first.Name} goes first");

        SimulateAttack(first, second);

        if (second.IsAlive())
        {
            SimulateAttack(second, first);
        }

        Debug.Log($"ROUND END");
    }

    private void SimulateAttack(Hero attacker, Hero defender)
    {
        Stats atkStats = Stats.Sum(attacker.BaseStats, attacker.Weapon.BonusStats);
        Stats defStats = Stats.Sum(defender.BaseStats, defender.Weapon.BonusStats);

        Debug.Log($"{attacker.Name} attacks {defender.Name}");

        if (!GameFormulas.HasHit(atkStats.aim, defStats.eva))
        {
            Debug.Log("Attack missed!");
            return;
        }

        int damage = GameFormulas.CalculateDamage(attacker, defender);
        defender.TakeDamage(damage);
        Debug.Log($"{defender.Name} takes {damage} damage. Remaining HP: {defender.Hp}");
    }

    private void InitRandomHeroes()
    {
        int R(int min, int max) => Random.Range(min, max + 1);

        Stats RandomStats() => new Stats(R(5, 20), R(5, 20), R(5, 20), R(5, 20), R(5, 20), R(50, 100), R(5, 20));
        ELEMENT RandomElement() => (ELEMENT)Random.Range(1, 4); // FIRE, ICE, LIGHTNING

        Weapon RandomWeapon(string name) => new Weapon(
            name,
            (Random.value > 0.5f) ? Weapon.DAMAGE_TYPE.PHYSICAL : Weapon.DAMAGE_TYPE.MAGICAL,
            RandomElement(),
            RandomStats()
        );

        ELEMENT r1 = RandomElement();
        ELEMENT w1;
        do { w1 = RandomElement(); } while (w1 == r1);

        ELEMENT r2 = RandomElement();
        ELEMENT w2;
        do { w2 = RandomElement(); } while (w2 == r2);

        a = new Hero("Hero A", R(60, 100), RandomStats(), r1, w1, RandomWeapon("Sword"));
        b = new Hero("Hero B", R(60, 100), RandomStats(), r2, w2, RandomWeapon("Staff"));

        Debug.Log("Random heroes created.");
    }
}
