using UnityEngine;

public class Archer : Character
{
    public Archer(string nome, int vita) : base(nome, vita) { }

    public override void Attack(Character target)
    {
        int frecce = 2;
        int dannoPerFreccia = 7;

        for (int i = 1; i <= frecce; i++)
        {
            Debug.Log($"{Nome} scaglia la freccia {i} infliggendo {dannoPerFreccia} danni");
            target.TakeDamage(dannoPerFreccia);
        }
    }

    public override void TakeDamage(int damage)
    {
        int vitaPrima = Vita;
        RiduciVita(damage);
        StampaStato("è stato colpito", damage, vitaPrima);
    }
}
