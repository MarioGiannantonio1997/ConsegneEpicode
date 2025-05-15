using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Proiettile
{
    protected float velocita;

    public Proiettile(float velocita)
    {
        this.velocita = velocita;
    }

    public abstract void Lancia();
}

