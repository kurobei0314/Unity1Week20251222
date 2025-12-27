using UnityEngine;
using System;

[Serializable]
public class JustRatioRange
{
    // ちょうどいい力加減の最初の範囲 //
    public float startJustRatio;

    // ちょうどいい力加減の最後の範囲 //
    public float endJustRatio;
}


public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private ScreenView m_ScreenView;
    [SerializeField] private InputController m_InputController;

    [SerializeField] private JustRatioRange m_JustRatioRange;

    private GameStateModel m_Model;
    private IResourceManager m_ResourceManager;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
        m_Model = new GameStateModel(m_JustRatioRange);
        m_InputController.Initialize(InputClick);
        m_ResourceManager = (IResourceManager)new ResourceManager();
        m_ScreenView.Initialize(m_ResourceManager);
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
        m_Model.JugdeResult();
        m_Model.SetState(GameStateModel.GameState.ResultAnimation);

        switch(m_Model.GetResult())
        {
            case GameStateModel.GameResult.UnderCharge:
                m_ScreenView.PlayUnderChargeResultAnimation(() => m_Model.SetState(GameStateModel.GameState.Result));
                break;
            case GameStateModel.GameResult.Just:
                m_ScreenView.PlayJustResultAnimation(() => m_Model.SetState(GameStateModel.GameState.Result));
                break;
            case GameStateModel.GameResult.OverCharge:
                m_ScreenView.PlayOverChargeResultAnimation(() => m_Model.SetState(GameStateModel.GameState.Result));
                break;
            default:
                break;
        }
    }

    private void Retry()
    {
        Debug.Log("wa------i");
        Initialize();
    }
}
