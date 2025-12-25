using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private ScreenView m_ScreenView;
    [SerializeField] private InputController m_InputController;

    private GameStateModel m_Model;

    private void Start()
    {
        m_Model = new GameStateModel();
        m_InputController.Initialize(InputClick);
    }

    private void Update()
    {
        if (m_Model.GetState() == GameStateModel.GameState.MainPlay)
        {
            m_Model.UpdateGaugeRatio();
            m_ScreenView.UpdateView(m_Model.GetBarRatio());
        }
    }

    private void InputClick()
    {
        if ( m_Model == null ) return;

        switch (m_Model.GetState())
        {
            case GameStateModel.GameState.MainPlay:
                PlayResultAnimation();
                break;
        }
    }

    private void PlayResultAnimation()
    {
        m_Model.SetState(GameStateModel.GameState.ResultAnimation);
        m_ScreenView.PlayResultAnimation(() => 
        {
            m_Model.SetState(GameStateModel.GameState.Result);
        });
    }
}
