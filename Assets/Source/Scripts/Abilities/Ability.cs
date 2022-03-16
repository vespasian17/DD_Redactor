using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[Serializable]
public class Ability : MonoBehaviour
{
    public List<int> ablePositionsForUseAbility = new List<int>();
    public List<int> ablePositionsForUseOnEnemy = new List<int>();
    public List<int> ablePositionsForUseOnAlly = new List<int>();
    public Sprite abilityIcon;
    public string abilityName;
}
