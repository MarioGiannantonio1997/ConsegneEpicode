using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3 : MonoBehaviour
{
    // ESERCIZIO 3: 
    // Le due vie piú dirette per dichiarare una variabile che poi viene esposta nell'Inspector sono:
    // 1. Dichiarare la variabile come public
    // 2. Dichiarare la variabile come private e aggiungere l'attributo [SerializeField] prima della dichiarazione

    // ESERCIZIO 4:
    public int primoNumero = 5;
    public int secondoNumero = 5;
    public int terzoNumero = 5;
    public int quartoNumero = 5;

    // ESERCIZIO 5:
    public int numeroEsercizio5 = 3;

    // ESERCIZIO 6 & 7:
    public int NumeroDiPartenza = 0;

    // ESERCIZIO 8:
    public int numero1 = 1;
    public int numero2 = 2;

    // ESERCIZIO 9:
    void Start()
    {
        Debug.Log("Hello World im start!");

        // ESERCIZIO 4:
        int somma = primoNumero + secondoNumero + terzoNumero + quartoNumero;
        int prodotto = primoNumero * secondoNumero * terzoNumero * quartoNumero;
        float media = somma / 4f;
        Debug.Log("Somma: " + somma);
        Debug.Log("Prodotto: " + prodotto);
        Debug.Log("Media: " + media);

        // ESERCIZIO 5:
        if (numeroEsercizio5 % 2 == 0)
        {
            Debug.Log("Il numero " + numeroEsercizio5 + " è pari.");
        }
        else
        {
            Debug.Log("Il numero " + numeroEsercizio5 + " è dispari.");
        }

        if (numeroEsercizio5 > 10)
        {
            Debug.Log("Il numero " + numeroEsercizio5 + " è maggiore di 10.");
        }
        else
        {
            Debug.Log("Il numero " + numeroEsercizio5 + " non è maggiore di 10.");
        }

        // ESERCIZIO 6:
        Stampa2Successivi();
        // ESERCIZIO 7:
        Stampa2Precedenti();
        // ESERCIZIO 8:
        MaggioreTra2Numeri();
        // ESERCIZIO 9:
        MinoreTra2Numeri();
        // ESERCIZIO 10:
        ControllaTempoPassato();
        // ESERCIZIO 11:
        CalcolaVoto();
    }

    void Update()
    {
        // Debug.Log("Hello World im update!");
    }

    public void Stampa2Successivi()
    {
        Debug.Log("Il numero di partenza è: " + NumeroDiPartenza);
        NumeroDiPartenza++;
        Debug.Log("Il numero incrementato è: " + NumeroDiPartenza);
        NumeroDiPartenza++;
        Debug.Log("Il numero incrementato x2 è: " + NumeroDiPartenza);
    }
    public void Stampa2Precedenti()
    {
        Debug.Log("Il numero di partenza è: " + NumeroDiPartenza);
        NumeroDiPartenza--;
        Debug.Log("Il numero decrementato è: " + NumeroDiPartenza);
        NumeroDiPartenza--;
        Debug.Log("Il numero decrementato x2 è: " + NumeroDiPartenza);
    }
    public void MaggioreTra2Numeri()
    {
        if (numero1 > numero2)
        {
            Debug.Log("Il numero maggiore è: " + numero1);
        }
        else if (numero2 > numero1)
        {
            Debug.Log("Il numero maggiore è: " + numero2);
        }
        else
        {
            Debug.Log("I numeri sono uguali!");
        }
    }
    public void MinoreTra2Numeri()
    {
        if (numero1 < numero2)
        {
            Debug.Log("Il numero minore è: " + numero1);
        }
        else if (numero2 < numero1)
        {
            Debug.Log("Il numero minore è: " + numero2);
        }
        else
        {
            Debug.Log("I numeri sono uguali!");
        }
        }
    public void ControllaTempoPassato()
    {
        float tempoIniziale = Time.time;

        if (tempoIniziale < 30)
        {
            Debug.Log("Sono passati meno di 30 secondi.");
        }
        else if (tempoIniziale >= 30 && tempoIniziale < 45)
        {
            Debug.Log("Sono passati più di 30 secondi.");
        }
        else if (tempoIniziale >= 45 && tempoIniziale < 60)
        {
            Debug.Log("Sono passati più di 45 secondi.");
        }
        else if (tempoIniziale >= 60)
        {
            Debug.Log("Sono passati più di 1 minuto.");
        }
    }
    public void CalcolaVoto()
    {
        int voto = 8; 
        string votoAmericano;

        if (voto == 10)
        {
            votoAmericano = "A+";
        }
        else if (voto == 9)
        {
            votoAmericano = "A";
        }
        else if (voto == 7 || voto == 8)
        {
            votoAmericano = "B";
        }
        else if (voto == 6)
        {
            votoAmericano = "C";
        }
        else if (voto == 5)
        {
            votoAmericano = "E";
        }
        else if (voto >= 0 && voto <= 4)
        {
            votoAmericano = "F";
        }
        else
        {
            votoAmericano = "Voto non valido";
        }

        Debug.Log("Il voto americano corrispondente è: " + votoAmericano);
    }
}
