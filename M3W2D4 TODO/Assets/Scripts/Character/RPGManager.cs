using System.Collections.Generic;
using UnityEngine;

public class RPGManager : MonoBehaviour
{
    void Start()
    {
        List<Character> characters = new List<Character>();

        characters.Add(new Warrior("Throg", 100));
        characters.Add(new Mage("Aeris", 80));
        characters.Add(new Archer("Lyna", 90));

        foreach (Character character in characters)
        {

            Debug.Log($"[PRIMA ATTACCO] {character.Nome} - Vita: {character.Vita}");

            Character target;
            do
            {
                target = characters[Random.Range(0, characters.Count)];
            } while (target == character);

            character.Attack(target);

            Debug.Log($"[DOPO ATTACCO] {character.Nome} - Vita: {character.Vita}");

            int randomDamage = Random.Range(1, 21);

            Debug.Log($"[PRIMA DANNI] {character.Nome} - Vita: {character.Vita}");

            character.TakeDamage(randomDamage);

            Debug.Log($"[DOPO DANNI] {character.Nome} - Vita: {character.Vita}");
        }
    }
}
