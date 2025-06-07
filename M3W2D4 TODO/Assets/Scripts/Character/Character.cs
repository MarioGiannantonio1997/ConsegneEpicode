using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
   public string Nome { get; private set; }
    public int Vita { get; private set; }

    public Character(string nome, int vita)
    {
        Nome = nome;
        Vita = vita;
    }

    public abstract void Attack(Character target);
    public abstract void TakeDamage(int damage);

    // Metodo di supporto per stampare lo stato
    protected void StampaStato(string azione, int danno, int vitaPrima)
    {
        Debug.Log($"{Nome} {azione} (danno: {danno}) - Vita prima: {vitaPrima}, Vita attuale: {Vita}");
    }

    protected void RiduciVita(int danno)
    {
        int vitaPrecedente = Vita;
        Vita -= danno;
        if (Vita < 0) Vita = 0;
    }
}

