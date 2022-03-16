using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kuhpik;
using UnityEngine;
using DG.Tweening;
using Supyrb;

public class UseAbilitySystem : GameSystemWithScreen<BattleUIScreen>, IIniting
{
    public void OnInit()
    {
        foreach (ButtonComponent buttonComponent in screen.buttons.Where(x => x.buttonType == ButtonType.Ability))
        {
            buttonComponent.button.onClick.AddListener(() =>
            {
                if (game.LastActiveAbilityButton == buttonComponent)
                {
                    game.CurrentBattleState = BattleState.None;
                    game.CurrentActiveAbility = null;
                    game.LastActiveAbilityButton = null;
                }
                else
                {
                    game.CurrentBattleState = BattleState.UseAbility;
                    game.CurrentActiveAbility = game.CurrentActiveCharacter.abilities[buttonComponent.index];
                    game.LastActiveAbilityButton = buttonComponent;
                }

                Signals.Get<ButtonsHoodSignal>().Dispatch(buttonComponent);
            });
        }

        foreach (CharacterComponent character in game.AllCharactersComponents)
        {
            character.clickAction += UseAbility;
        }
    }
    private void UseAbility(CharacterComponent clickedCharacter)
    {
        if (game.CurrentActiveAbility == null) return;
        
        Signals.Get<ApplyAbilityEffectOnCharacterSignal>().Dispatch(clickedCharacter, game.CurrentActiveAbility);
    }
}
