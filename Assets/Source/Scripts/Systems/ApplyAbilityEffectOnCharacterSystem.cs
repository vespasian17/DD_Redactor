using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kuhpik;
using Supyrb;

public class ApplyAbilityEffectOnCharacterSystem : GameSystem, IIniting
{
    public void OnInit()
    {
        Signals.Get<ApplyAbilityEffectOnCharacterSignal>().AddListener(ApplyAbilityEffect);
    }

    private void ApplyAbilityEffect(CharacterComponent clickedCharacterComponent, Ability ability)
    {
        if (ability is IDamage damage) damage.DealDamage(clickedCharacterComponent);

        //
        clickedCharacterComponent.healthBarComponent.SetHealthBarValue(clickedCharacterComponent.currentHealth);
        Signals.Get<NextTurnSignal>().Dispatch();
    }
}
