using System.Collections;
using System.Collections.Generic;
using Kuhpik;
using UnityEngine;
using DG.Tweening;
using Supyrb;

public class BlockingInterfaceSystem : GameSystemWithScreen<BattleUIScreen>, IIniting
{
    public void OnInit()
    {
        Signals.Get<BlockInterfaceSignal>().AddListener(BlockInterface);
        Signals.Get<UnlockInterfaceSignal>().AddListener(UnlockInterface);
    }

    private void BlockInterface()
    {
        foreach (var buttonComponent in screen.buttons)
        {
            buttonComponent.hood.gameObject.SetActive(false);
            buttonComponent.button.interactable = false;
        }
        screen.skipTurnButton.button.interactable = false;
    }

    private void UnlockInterface()
    {
        foreach (var buttonComponent in screen.buttons)
        {
            buttonComponent.button.interactable = true;
        }
        screen.skipTurnButton.button.interactable = true;
    }
}
