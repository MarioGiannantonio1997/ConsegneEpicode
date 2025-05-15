using UnityEngine;

public class Mage : Character
{
    public Mage(string nome, int vita) : base(nome, vita) { }

    public override void Attack(Character target)
    {
        int danno = 12;
        Debug.Log($"{Nome} lancia una palla di fuoco!");
        target.TakeDamage(danno);
    }

    public override void TakeDamage(int damage)
    {
        int vitaPrima = Vita;
        RiduciVita(damage);
        StampaStato("subisce danno magico", damage, vitaPrima);
    }
}
