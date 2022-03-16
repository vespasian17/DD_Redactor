using UnityEngine.UI;
using Supyrb;
using Kuhpik;

public class ButtonsHoodSystem : GameSystemWithScreen<BattleUIScreen>, IIniting
{
    public void OnInit()
    {
        Signals.Get<ButtonsHoodSignal>().AddListener(SetHoodStatus);
        Signals.Get<ResetHoodsSignal>().AddListener(ResetHood);
    }

    private void SetHoodStatus(ButtonComponent buttonComponent)
    {
        foreach (var button in screen.buttons)
        {
            if (button == buttonComponent && button.hood.gameObject.activeSelf) button.hood.gameObject.SetActive(false);
            else if (button == buttonComponent && !button.hood.gameObject.activeSelf) button.hood.gameObject.SetActive(true);
            
            if (button != buttonComponent) button.hood.gameObject.SetActive(false);
        }
    }

    private void ResetHood()
    {
        foreach (var button in screen.buttons)
        {
            button.hood.gameObject.SetActive(false);
        }
    }
}
