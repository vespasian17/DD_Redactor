using NaughtyAttributes;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "CharactersObjectInfo", menuName = "App/CharactersSetup", order = 1)]
public class CharactersSetup : ScriptableObject
{
    [SerializeField] private List<CharactersObject> allies;
    [SerializeField] private List<CharactersObject> enemies;

    public List<CharactersObject> GetAlliesList()
    {
        return allies;
    }
    public List<CharactersObject> GetEnemiesList()
    {
        return enemies;
    }
    
        
    [Serializable]
    public class CharactersObject
    {
        [SerializeField] private GameObject characterPrefab;
        [SerializeField] private int baseInitiative;
        [SerializeField] private int baseHealth;
        [SerializeField] private int maxHealth;
        public GameObject CharacterPrefab => characterPrefab;
        public int BaseInitiative => baseInitiative;
        public int BaseHealth => baseHealth;

        public int MaxHealth => maxHealth;
    }
}
