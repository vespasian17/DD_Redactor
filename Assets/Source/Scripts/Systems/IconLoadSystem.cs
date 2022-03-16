using Kuhpik;
using Supyrb;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class IconLoadSystem : GameSystemWithScreen<BattleUIScreen>, IIniting
{
    public void OnInit()
    {
        Signals.Get<LoadIconSignal>().AddListener(LoadIcon);
    }

    private void LoadIcon()
    {
        var i = 0;
        foreach (var button in screen.buttons.Where(x => x.buttonType == ButtonType.Ability).ToArray()) 
        {
            button.abilityIcon.sprite = game.CurrentActiveCharacter.abilities[i].abilityIcon;
            i++;
        }
    }
}
