using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burn : Ability, IDamage
{
    [SerializeField] private int damage;

    public void DealDamage(CharacterComponent clickedCharacterComponent)
    {
        clickedCharacterComponent.currentHealth -= damage;
    }
}
