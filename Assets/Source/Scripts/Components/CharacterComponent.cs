using UnityEngine;
using UnityEngine.EventSystems;
using System;
using System.Collections.Generic;

public class CharacterComponent : MonoBehaviour, IPointerClickHandler
{
    public int baseInitiative;
    public int initiative;
    public int baseHealth;
    public int currentHealth;
    public int maxHealth;
    public bool isAlly;
    public Action<CharacterComponent> clickAction;
    public List<Ability> abilities;
    public HealthBarComponent healthBarComponent;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        clickAction?.Invoke(this);
    }
}
