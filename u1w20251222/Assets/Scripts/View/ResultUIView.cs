using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ResultUIView : MonoBehaviour
{
    [SerializeField] private TMP_Text m_ResultText; 
    [SerializeField] private Animator m_Animator;

    public void Initialize()
    {
    }

    public void PlayUnderChargeAnimation()
    {
        m_ResultText.text = "かまくら無傷だった";
        PlayResultUIAnimation();
    }

    public void PlayJustAnimation()
    {
        m_ResultText.text = "かまくら作れた";
        PlayResultUIAnimation();
    }
    public void PlayOverChargeAnimation()
    {
        m_ResultText.text = "かまくら貫通した";
        PlayResultUIAnimation();
    }

    private void PlayResultUIAnimation()
    {
        m_Animator.SetTrigger("PlayResult");
    }

    public void PlayRetryAnimation()
        => m_Animator.SetTrigger("Retry");
}
