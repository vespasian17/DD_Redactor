using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kuhpik;
using Supyrb;
using UnityEngine;

public class CalculateInitiativeSystem : GameSystem, IIniting
{
    [SerializeField] private int minRandomInitiative;
    [SerializeField] private int maxRandomInitiative;
    
    private int _baseInitiative;
    private int _randomInitiative;
    public void OnInit()
    {
        Signals.Get<CalculateInitiativeSignal>().AddListener(CalculateInitiative);
        
        CalculateInitiative();
    }

    private void CalculateInitiative()
    {
        foreach (var character in game.AllCharactersComponents)
        {
            _randomInitiative = Random.Range(minRandomInitiative, maxRandomInitiative + 1);
            _baseInitiative = character.baseInitiative;

            character.initiative = _baseInitiative + _randomInitiative;
        }

        var sortingList = game.AllCharactersComponents.OrderByDescending(x => x.initiative);
        game.AllCharactersComponents = sortingList.ToList();
    } 
}
