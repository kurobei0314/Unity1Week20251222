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

    public GameStateModel()
    {
        SetState(GameState.MainPlay);
    }

    public void SetState(GameState state)
        => m_State = state;
    
    public GameState GetState()
        => m_State;
}
