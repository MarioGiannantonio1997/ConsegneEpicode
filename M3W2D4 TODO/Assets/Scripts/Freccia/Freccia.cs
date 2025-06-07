using UnityEngine;

public class Freccia : Proiettile
{
    public Freccia(float velocita) : base(velocita) { }

    public override void Lancia()
    {
        Debug.Log($"Freccia lanciata a velocità {velocita}");
    }
}
