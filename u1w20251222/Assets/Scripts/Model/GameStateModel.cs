using UnityEngine;

public class GameStateModel
{
    public enum GameState
    {
        MainPlay,
        ResultAnimation,
        Result,
    }

    public enum GameResult
    {
        None,
        UnderCharge,
        Just,
        OverCharge,
    }

    private GameState m_State;
    private GameResult m_Result;
    private float m_BarRatio;
    private JustRatioRange m_JustRatioRange;

    public GameStateModel(JustRatioRange justRatioRange)
    {
        SetState(GameState.MainPlay);
        SetResult(GameResult.None);
        m_BarRatio = 0;
        m_JustRatioRange = justRatioRange;
    }

    public void SetState(GameState state)
        => m_State = state;

    private void SetResult(GameResult state)
        => m_Result = state;
    
    public void JugdeResult()
    {
        if      (m_BarRatio < m_JustRatioRange.startJustRatio) SetResult(GameResult.UnderCharge);
        else if (m_JustRatioRange.endJustRatio < m_BarRatio)   SetResult(GameResult.OverCharge);
        else                                                   SetResult(GameResult.Just);
    }


    public GameState GetState()
        => m_State;
    
    public GameResult GetResult()
        => m_Result;

    public void UpdateGaugeRatio()
        => m_BarRatio = m_BarRatio == 1.0f ?  0.0f : Mathf.Clamp( m_BarRatio + Time.deltaTime, 0.0f, 1.0f);
    
    public float GetBarRatio()
        => m_BarRatio;
    
}
