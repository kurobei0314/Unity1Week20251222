using UnityEngine;

public class InputController : MonoBehaviour
{
    private ScreenView m_ScreenView;
    private GameStateModel m_GameStateModel;

    public void Initialize(ScreenView view, GameStateModel model)
    {
        m_ScreenView = view;
        m_GameStateModel = model;
    }

    #region ClickHandler
    public void InputClickArea()
    {
        Debug.Log("wa----i");
    }
    #endregion
}
