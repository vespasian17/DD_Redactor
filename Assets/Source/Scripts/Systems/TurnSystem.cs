using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using UnityEngine;
using DG.Tweening;
using Supyrb;

public class TurnSystem : GameSystemWithScreen<BattleUIScreen>, IIniting
{
    private int roundCounter;
    private int currentCharacterIndex;
    private Sequence anim;
    public void OnInit()
    {
        NewRound();
        screen.skipTurnButton.button.onClick.AddListener(NextTurn);
        SetActiveCharacter(currentCharacterIndex);
        Signals.Get<NextTurnSignal>().AddListener(NextTurn);
        if (game.CurrentActiveCharacter.isAlly) Signals.Get<LoadIconSignal>().Dispatch();
    }

    private void NextTurn()
    {
        game.CurrentBattleState = BattleState.None;
        game.CurrentActiveAbility = null;
        game.LastActiveAbilityButton = null;
        currentCharacterIndex++;

        if (currentCharacterIndex == game.AllCharactersComponents.Count)
        {
            currentCharacterIndex = 0;
            NewRound();
            Signals.Get<CalculateInitiativeSignal>().Dispatch();
        }

        SetActiveCharacter(currentCharacterIndex);
        Signals.Get<ResetHoodsSignal>().Dispatch();

        if (game.CurrentActiveCharacter.isAlly)
        {
            Signals.Get<LoadIconSignal>().Dispatch();
            Signals.Get<UnlockInterfaceSignal>().Dispatch();
            Signals.Get<CheckAvailableAbilitiesSignal>().Dispatch();
        }
        else NextTurn();
    }

    private void SetActiveCharacter(int index)
    {
        //Проверка есть ли текущий персонаж, если он есть, то убиваем его анимацию при переходе хода
        if (game.CurrentActiveCharacter != null)
        {
            anim.Kill();
            game.CurrentActiveCharacter.transform.DOLocalMoveY(0f, 0.1f);
        }

        game.CurrentActiveCharacter = game.AllCharactersComponents[index]; //Получение текущего персонажа

        //Создание анимации текущего хода персонажа
        anim = DOTween.Sequence();
        anim.Append(game.CurrentActiveCharacter.transform.DOLocalMoveY(0.25f, 0.3f));
        anim.Append(game.CurrentActiveCharacter.transform.DOLocalMoveY(0f, 0.3f));
        anim.SetLoops(-1, LoopType.Restart);
    }

    private void NewRound()
    {
        roundCounter++;
        screen.roundCounterText.text = "Round " + roundCounter;
    }

}
