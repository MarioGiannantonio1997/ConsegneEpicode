using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lab3 : MonoBehaviour
{
    // ESERCIZIO 1
    public int index = 5;
    public int num = 10;

    // ESERCIZIO 2
    int[] numeri = { 2, 4, 6, 8 };
    int somma = 0;
    int prodotto = 1;

    // ESERCIZIO 4
    public int start = 5;
    public int amount = 3;
    // ESERCIZIO 5
    public int find = 5;
    public int arraySize = 10;
    // ESERCIZIO 6


    public int numero;

    void Start()
    {

    }

    void Update()
    {
        //esercizio1();
        //esercizio2();
        //esercizio3();
        //esercizio4();
        //esercizio5();
        //esercizio6();
        esercizio7();
    }

    private void esercizio1()
    {
        Debug.Log(" ---- ESERCIZIO 1 ---- ");
        while (index > 0)
        {
            num++;
            Debug.Log(num);
            index--;
        }
        Debug.Log(" ---- FINE ESERCIZIO 1 ---- ");
    }

    private void esercizio2()
    {
        Debug.Log(" ---- ESERCIZIO 2 ---- ");
        for (int i = 0; i < numeri.Length; i++)
        {
            somma += numeri[i];
            prodotto *= numeri[i];

            Debug.Log($"Iterazione {i + 1}: Somma = {somma}, Prodotto = {prodotto}");

            if (i == 1)
            {
                break;
            }
        }
        Debug.Log(" ---- FINE ESERCIZIO 2 ---- ");
    }

    private void esercizio3()
    {
        Debug.Log(" ---- ESERCIZIO 3 ---- ");
        for (int i = 1; i <= 30; i++)
        {
            if (i % 3 == 0 && i % 5 == 0)
            {
                Debug.Log("FizzBuzz");
            }
            else if (i % 3 == 0)
            {
                Debug.Log("Fizz");
            }
            else if (i % 5 == 0)
            {
                Debug.Log("Buzz");
            }
            else
            {
                Debug.Log(i);
            }
        }
        Debug.Log(" ---- FINE ESERCIZIO 3 ---- ");
    }

    private void esercizio4()
    {
        for (int i = start; i <= start + amount; i++)
        {
            Debug.Log(i);
        }
    }

    private void esercizio5()
    {
        int[] numeri = new int[arraySize];

        // Riempio l'array con numeri casuali tra 0 e find 
        for (int i = 0; i < numeri.Length; i++)
        {
            numeri[i] = Random.Range(0, find + 1);  // include anche find

            if (numeri[i] == find)
            {
                Debug.Log("found");
            }
            else
            {
                Debug.Log("not found");
            }
        }


    }

    // ESERCIZIO 6 
    private void esercizio6()
    {
        int[] mioArray = GeneraArray();
        StampaArray(mioArray);
        int somma = SommaArray(mioArray);
        Debug.Log("Somma totale: " + somma);
    }
    int[] GeneraArray()
    {
        int[] array = new int[20];
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(1, 101); // 101 escluso, quindi 1-100 inclusi
        }
        return array;
    }
    int SommaArray(int[] array)
    {
        int somma = 0;
        foreach (int numero in array)
        {
            somma += numero;
        }
        return somma;
    }
    void StampaArray(int[] array)
    {
        Debug.Log("Contenuto dell'array:");
        foreach (int numero in array)
        {
            Debug.Log(numero);
        }
    }

    // ESERCIZIO 7
    private void esercizio7() {
        int[] mioArray = new int[20];
        GeneraArray2(mioArray, 10, 50); // Popola l'array con valori tra 10 e 50
        StampaArray2(mioArray);
        int somma = SommaArray2(mioArray);
        Debug.Log("Somma totale: " + somma);
     }

      void GeneraArray2(int[] array, int minimo, int massimo)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = Random.Range(minimo, massimo + 1); // massimo escluso, quindi +1
        }
    }

     int SommaArray2(int[] array)
    {
        int somma = 0;
        foreach (int numero in array)
        {
            somma += numero;
        }
        return somma;
    }

    void StampaArray2(int[] array)
    {
        Debug.Log("Contenuto dell'array:");
        foreach (int numero in array)
        {
            Debug.Log(numero);
        }
    }
}
