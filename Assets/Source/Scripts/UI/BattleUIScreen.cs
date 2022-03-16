using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleUIScreen : UIScreen
{
    [BoxGroup("Buttons")] public ButtonComponent skipTurnButton;
    [BoxGroup("Buttons")] public List<ButtonComponent> buttons;
    [BoxGroup("TextMessages")] public TextMeshProUGUI roundCounterText;
}

public enum ButtonType
{
    Ability,
    Move
}
