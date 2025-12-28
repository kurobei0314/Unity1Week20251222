using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class ResultUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text m_ResultText; 
    [SerializeField] private Animator m_Animator;

    private Action finishAnimAction;
    public void Initialize()
    {
    }

    public void PlayUnderChargeAnimation(Action finishAction)
    {
        m_ResultText.text = "かまくら無傷だった";
        PlayResultUIAnimation();
        finishAnimAction = finishAction;
    }

    public void PlayJustAnimation(Action finishAction)
    {
        m_ResultText.text = "かまくら作れた";
        PlayResultUIAnimation();
        finishAnimAction = finishAction;
    }
    public void PlayOverChargeAnimation(Action finishAction)
    {
        m_ResultText.text = "かまくら貫通した";
        PlayResultUIAnimation();
        finishAnimAction = finishAction;
    }

    private void PlayResultUIAnimation()
    {
        m_Animator.SetTrigger("PlayResult");
    }

    public void PlayRetryAnimation()
        => m_Animator.SetTrigger("Retry");

    public void ActionFromPlayResultAnimEnd()
    {
        finishAnimAction?.Invoke();
        finishAnimAction = null;
    }
}
