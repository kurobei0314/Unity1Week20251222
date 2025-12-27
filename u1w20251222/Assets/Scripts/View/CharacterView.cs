using UnityEngine;

public class CharacterView : MonoBehaviour
{
    // 一旦、配列の状態は以下のようになる
    // 0: Idle状態
    // 1: パンチ前状態
    // 2: パンチ状態
    [SerializeField] private Transform[] m_playerRenderers;
    public void Initialize()
    {
        m_playerRenderers[0].gameObject.SetActive(true);
        for (var i = 1; i < m_playerRenderers.Length; i++)
        {
            m_playerRenderers[i].gameObject.SetActive(false);
        }
    }

    public void WindUp()
    {
        m_playerRenderers[0].gameObject.SetActive(false);
        m_playerRenderers[1].gameObject.SetActive(true);
    }

    public void Punch()
    {
        m_playerRenderers[1].gameObject.SetActive(false);
        m_playerRenderers[2].gameObject.SetActive(true);
    }
}
