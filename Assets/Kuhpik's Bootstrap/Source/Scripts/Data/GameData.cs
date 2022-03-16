using System.Collections.Generic;
using UnityEngine;

namespace Kuhpik
{
    public class GameData
    {
        //------------------BATTLE----------------------//
        public List<AllyPosComponent> AllyPosComponents = new List<AllyPosComponent>();
        public List<EnemyPosComponent> EnemyPosComponents = new List<EnemyPosComponent>();
        
        public List<CharacterComponent> AllCharactersComponents = new List<CharacterComponent>();
        public List<CharacterComponent> AllyCharacters = new List<CharacterComponent>();
        public List<CharacterComponent> EnemyCharacters = new List<CharacterComponent>();

        public CharacterComponent CurrentActiveCharacter;
        public int CurrentPositionIndex => CurrentActiveCharacter.GetComponentInParent<AllyPosComponent>().index;
 
        public BattleState CurrentBattleState;
        public ButtonComponent LastActiveAbilityButton;
        public Ability CurrentActiveAbility;

    }

    public enum BattleState
    {
        None,
        
        Move,
        UseAbility,
    }
}