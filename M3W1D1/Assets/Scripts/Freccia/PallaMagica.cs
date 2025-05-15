using UnityEngine;

public class PallaMagica : Proiettile
{
    public PallaMagica(float velocita) : base(velocita) { }

    public override void Lancia()
    {
        Debug.Log($"Palla Magica lanciata a velocità {velocita}");
    }
}
