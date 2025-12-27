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

    public GameStateModel()
    {
        SetState(GameState.MainPlay);
        SetResult(GameResult.None);
        m_BarRatio = 0;
    }

    public void SetState(GameState state)
        => m_State = state;

    private void SetResult(GameResult state)
        => m_Result = state;
    
    public void JugdeResult()
    {
        // TODO: あとで結果を求められるようにする
        SetResult(GameResult.UnderCharge);
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
