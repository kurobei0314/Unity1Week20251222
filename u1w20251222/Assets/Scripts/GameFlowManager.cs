using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private ScreenView m_ScreenView;
    [SerializeField] private InputController m_InputController;

    private GameStateModel m_Model;
    private IResourceManager m_ResourceManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        m_Model = new GameStateModel();
        m_InputController.Initialize(InputClick);
        m_ResourceManager = (IResourceManager)new ResourceManager();

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
            case GameStateModel.GameState.Result:
                Retry();
                break;
        }
    }

    private void PlayResultAnimation()
    {
        m_Model.SetState(GameStateModel.GameState.ResultAnimation);
        m_ScreenView.PlayResultAnimation(() => 
        {
            Debug.Log("Result Status");
            m_Model.SetState(GameStateModel.GameState.Result);
        });
    }

    private void Retry()
    {
        Debug.Log("wa------i");
        Initialize();
    }
}
