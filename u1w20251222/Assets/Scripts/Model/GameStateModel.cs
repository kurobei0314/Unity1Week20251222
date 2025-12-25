using UnityEngine;

public class GameStateModel
{
    public enum GameState
    {
        MainPlay,
        ResultAnimation,
        Result,
    }
    private GameState m_State;
    private float m_BarRatio;
    private float result;

    public GameStateModel()
    {
        SetState(GameState.MainPlay);
        m_BarRatio = 0;
    }

    public void SetState(GameState state)
        => m_State = state;
    
    public GameState GetState()
        => m_State;

    public void UpdateGaugeRatio()
        => m_BarRatio = m_BarRatio == 1.0f ?  0.0f : Mathf.Clamp( m_BarRatio + Time.deltaTime, 0.0f, 1.0f);
    
    public float GetBarRatio()
        => m_BarRatio;
    
}
