using UnityEngine;
using System;

public class StartUIView : MonoBehaviour
{
    [SerializeField] private Animator m_Animator;
    private Action finishAnimAction;

    public void Initialize()
    {

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
}
