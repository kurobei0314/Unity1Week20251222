using UnityEngine;
using System;
using Cysharp.Threading.Tasks;

public class ScreenView : MonoBehaviour
{
    [SerializeField] private BarView m_BarView;
    [SerializeField] private CharacterView m_Character;
    [SerializeField] private SnowView m_Snow;
    [SerializeField] private StartUIView m_StartUIView;
    [SerializeField] private ResultUIView m_ResultUIView;
    private IResourceManager m_ResourceManager;

    public void Initialize(IResourceManager resourceManager, Action finishAnimAction)
    {
        m_ResourceManager = resourceManager;
        InitializeView();
        m_StartUIView.PlayStartAnimation(finishAnimAction);
    }

    private void InitializeView()
    {
        m_BarView.Initialize();
        m_Character.Initialize();
        m_Snow.Initialize();
        m_ResultUIView.Initialize();
        m_StartUIView.Initialize(m_ResourceManager);
    }

    public void Retry()
    {
        m_ResultUIView.PlayRetryAnimation();
        InitializeView();
    }

    public void UpdateView(float ratio)
    {
        m_BarView.UpdateView(ratio);
    }

    private async UniTask PlayAnimation(string seName, Action playSnowAnimation, Action finishCallback)
    {
        var token = this.GetCancellationTokenOnDestroy();
        m_Character.WindUp();
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f), cancellationToken: token);
        var load = false;
        m_ResourceManager.LoadAsync<GameObject>( "Hit", (obj) =>
        {
            var go = Instantiate (obj) as GameObject;
            m_Snow.SetEffectParent(go);
            m_ResourceManager.LoadAsync<AudioClip>(seName, (audioClip) => AudioManager.Instance.PlaySE(audioClip));
            m_Character.Punch();
            load = true;
        } );
        await UniTask.WaitUntil(() => load, cancellationToken: token); 
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f), cancellationToken: token);
        playSnowAnimation?.Invoke();
        await UniTask.Delay(TimeSpan.FromSeconds(1.0f), cancellationToken: token);
        finishCallback?.Invoke();
    }

    public async UniTask PlayUnderChargeResultAnimation(Action finishCallback)
    {
        PlayAnimation("UnderChargeSE", () => {
                m_Snow.SetUnderChargeState();
            },() => {
                m_ResultUIView.PlayUnderChargeAnimation(finishCallback);
        });
    }

    public async UniTask PlayJustResultAnimation(Action finishCallback)
    {
        PlayAnimation("JustSE", () => {
                m_Snow.SetJustState();
            }, () => {
                m_ResultUIView.PlayJustAnimation(finishCallback);
        });
    }

    public async UniTask PlayOverChargeResultAnimation(Action finishCallback)
    {
        PlayAnimation("OverChargeSE", () => {
                m_Snow.SetOverChargeState();
            },() =>  {
                m_ResultUIView.PlayOverChargeAnimation(finishCallback);
        });
    }
}
