using UnityEngine;

public class Warrior : Character
{
    public Warrior(string nome, int vita) : base(nome, vita) { }

    public override void Attack(Character target)
    {
        int danno = 10;
        Debug.Log($"{Nome} colpisce con una spadata!");
        target.TakeDamage(danno);
    }

    public override void TakeDamage(int damage)
    {
        int vitaPrima = Vita;
        RiduciVita(damage);
        StampaStato("riceve un colpo", damage, vitaPrima);
    }
}