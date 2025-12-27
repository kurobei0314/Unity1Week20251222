using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private BarView m_BarView;
    [SerializeField] private CharacterView m_Character;
    [SerializeField] private SnowView m_Snow;

    public void Initialize()
    {
        m_BarView.Initialize();
        m_Character.Initialize();
        m_Snow.Initialize();
    }

    public void UpdateView(float ratio)
    {
        m_BarView.UpdateView(ratio);
    }

    private async UniTask PlayAnimation(Action finishCallback)
    {
        var token = this.GetCancellationTokenOnDestroy();
        m_Character.WindUp();
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f), cancellationToken: token);
        m_Character.Punch();
        token = this.GetCancellationTokenOnDestroy();
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f), cancellationToken: token);
        finishCallback?.Invoke();
    }

    public async UniTask PlayUnderChargeResultAnimation(Action finishCallback)
    {
        PlayAnimation(() => 
        {
            m_Snow.SetUnderChargeState();
            finishCallback?.Invoke();
        });
    }
}
