using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using UnityEngine;
using DG.Tweening;
using Supyrb;

public class AllyMovementSystem : GameSystemWithScreen<BattleUIScreen>, IIniting
{
    public void OnInit()
    {
        var moveButtonComponent = screen.buttons.Find(x => x.buttonType == ButtonType.Move);
        moveButtonComponent.button.onClick.AddListener(() => 
        {
            game.CurrentBattleState = game.CurrentBattleState != BattleState.Move ? BattleState.Move : BattleState.None;
            game.CurrentActiveAbility = null;
            game.LastActiveAbilityButton = null;
            
            Signals.Get<ButtonsHoodSignal>().Dispatch(moveButtonComponent);
        });

        foreach(CharacterComponent character in game.AllyCharacters)
        {
            character.clickAction += Move;
        }
    }
    
    private void Move(CharacterComponent clickedCharacter)
    {
        if (game.CurrentBattleState != BattleState.Move || game.CurrentActiveCharacter == clickedCharacter) return;
        Signals.Get<BlockInterfaceSignal>().Dispatch();

        var _currentIndexTransform = game.CurrentPositionIndex;
        var _clickedIndexTransform = clickedCharacter.GetComponentInParent<AllyPosComponent>().index;
        if (_currentIndexTransform < _clickedIndexTransform)
        {

            while (_currentIndexTransform < _clickedIndexTransform)
            {
                var temporaryCharacter = game.AllyPosComponents[_currentIndexTransform + 1].GetComponentInChildren<CharacterComponent>();
                temporaryCharacter.transform.SetParent(game.AllyPosComponents[_currentIndexTransform].transform);
                temporaryCharacter.transform.DOLocalMove(Vector3.zero, 0.5f);

                _currentIndexTransform++;
            }
            game.CurrentActiveCharacter.transform.SetParent(game.AllyPosComponents[_clickedIndexTransform].transform);
            game.CurrentActiveCharacter.transform.DOLocalMove(Vector3.zero, 0.5f)
                .OnComplete((() => Signals.Get<NextTurnSignal>().Dispatch())); //Делаем пропуск хода после смены
        }

        if (_currentIndexTransform > _clickedIndexTransform)
        {

            while (_currentIndexTransform > _clickedIndexTransform)
            {
                var temporaryCharacter = game.AllyPosComponents[_currentIndexTransform - 1].GetComponentInChildren<CharacterComponent>();
                temporaryCharacter.transform.SetParent(game.AllyPosComponents[_currentIndexTransform].transform);
                temporaryCharacter.transform.DOLocalMove(Vector3.zero, 0.5f);

                _currentIndexTransform--;
            }
            game.CurrentActiveCharacter.transform.SetParent(game.AllyPosComponents[_clickedIndexTransform].transform);
            game.CurrentActiveCharacter.transform.DOLocalMove(Vector3.zero, 0.5f)
                .OnComplete((() => Signals.Get<NextTurnSignal>().Dispatch())); //Делаем пропуск хода после смены
        }
    }

}
