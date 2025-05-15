using System.Collections.Generic;
using UnityEngine;

public class ProiettileTest : MonoBehaviour
{
    private List<Proiettile> proiettili = new List<Proiettile>();

    void Start()
    {
        // Creo diversi proiettili 
        proiettili.Add(new Freccia(25f));
        proiettili.Add(new PallaMagica(18f));
        proiettili.Add(new Freccia(30f));
        proiettili.Add(new PallaMagica(22f));

        // Chiamiamo Lancia() per ciascun proiettile
        foreach (Proiettile p in proiettili)
        {
            p.Lancia();
        }
    }
}
