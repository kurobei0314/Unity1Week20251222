using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private BarView m_BarView;
    [SerializeField] private CharacterView m_Character;
    [SerializeField] private SnowView m_Snow;
    private IResourceManager m_ResourceManager;

    public void Initialize(IResourceManager resourceManager)
    {
        m_BarView.Initialize();
        m_Character.Initialize();
        m_Snow.Initialize();
        m_ResourceManager = resourceManager;
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
        var load = false;
        m_ResourceManager.LoadAsync<GameObject>( "Hit", (obj) =>
        {
            var go = Instantiate (obj) as GameObject;
            m_Snow.SetEffectParent(go);
            m_Character.Punch();
            load = true;
        } );
        await UniTask.WaitUntil(() => load, cancellationToken: token); 
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

    public async UniTask PlayJustResultAnimation(Action finishCallback)
    {
        PlayAnimation(() => 
        {
            m_Snow.SetJustState();
            finishCallback?.Invoke();
        });
    }

    public async UniTask PlayOverChargeResultAnimation(Action finishCallback)
    {
        PlayAnimation(() => 
        {
            m_Snow.SetOverChargeState();
            finishCallback?.Invoke();
        });
    }
}
