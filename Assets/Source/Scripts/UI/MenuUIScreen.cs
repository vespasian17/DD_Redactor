using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIScreen : UIScreen
{
    [SerializeField] private Button playButton;

    public override void Subscribe()
    {
        playButton.onClick.AddListener(() => Bootstrap.ChangeGameState(EGamestate.Battle));
    }
}
