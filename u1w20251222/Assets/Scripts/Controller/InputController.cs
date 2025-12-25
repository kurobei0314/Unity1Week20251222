using UnityEngine;
using System;

public class InputController : MonoBehaviour
{
    private Action m_OnClick;
    public void Initialize(Action onClick)
    {
        m_OnClick = onClick;
    }

    #region ClickHandler
    public void InputClickArea()
    {
        m_OnClick.Invoke();
    }
    #endregion
}
