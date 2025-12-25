using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private ScreenView m_ScreenView;
    [SerializeField] private InputController m_InputController;

    private GameStateModel m_Model;

    private void Start()
    {
        m_Model = new GameStateModel();
        m_InputController.Initialize(m_ScreenView, m_Model);
    }

    private void Update()
    {
        if (m_Model.GetState() == GameStateModel.GameState.MainPlay)
        {
            m_ScreenView.UpdateView();
        }
    }
}
