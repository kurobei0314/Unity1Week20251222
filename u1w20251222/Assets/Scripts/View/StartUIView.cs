using UnityEngine;
using System;

public class StartUIView : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    private Action finishAnimAction;
    private IResourceManager m_ResourceManager;

    public void Initialize(IResourceManager resourceManager)
    {
        m_ResourceManager = resourceManager;
    }

    public void PlayStartAnimation(Action finishAction)
    {
        m_Animator.SetTrigger("StartAnimation");
        finishAnimAction = finishAction;
    }

    public void ActionFromPlayResultAnimEnd()
    {
        finishAnimAction?.Invoke();
        finishAnimAction = null;
    }

    public void PlaySEInAnimation()
    {
        m_ResourceManager.LoadAsync<AudioClip>("GuideSE", (audioClip) =>
        {
            AudioManager.Instance.PlaySE(audioClip);
        });
    }
}
