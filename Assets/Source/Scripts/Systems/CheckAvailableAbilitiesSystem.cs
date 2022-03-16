using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Kuhpik;
using Supyrb;
using UnityEngine;

public class CheckAvailableAbilitiesSystem : GameSystemWithScreen<BattleUIScreen>, IIniting
{
    public void OnInit()
    {
        CheckAvailableAbilities();
        Signals.Get<CheckAvailableAbilitiesSignal>().AddListener(CheckAvailableAbilities);
    }
    
    private void CheckAvailableAbilities()
    {
        for (int i = 0; i < game.AllyCharacters.Count; i++) //Проходим по всем персонажам; i - персонаж
        {
            if (game.AllyCharacters[i] == game.CurrentActiveCharacter) //Если проходной персонаж текущий
            {
                var characterPositionIndex = game.CurrentPositionIndex;
                for (var abilityIndex = 0; abilityIndex < game.CurrentActiveCharacter.abilities.Count; abilityIndex++)
                {
                    var ability = game.CurrentActiveCharacter.abilities[abilityIndex];

                    if (ability.ablePositionsForUseAbility == null ||
                        ability.ablePositionsForUseAbility.Count == 0)
                        continue; //Если доступная позиция не существует или списка позиций не существует, выходим из цикла

                    var buttonComponent  = screen.buttons.Where(x => x.buttonType == ButtonType.Ability).ToList()
                        .Find(x => x.index == abilityIndex);
                    
                    if (ability.ablePositionsForUseAbility.Contains(characterPositionIndex)) //Если в листе доступных позиций есть индекс персонажа, то выполняем дальше
                    {
                        buttonComponent.button.interactable = true;
                    }
                    else
                    {
                        buttonComponent.button.interactable = false;
                    }
                }
            }
        }
    }
}
