using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private ScreenView m_ScreenView;
    [SerializeField] private InputController m_InputController;

    private void Start()
    {
        var model = new GameStateModel();
        m_InputController.Initialize(m_ScreenView, model);
    }

}
