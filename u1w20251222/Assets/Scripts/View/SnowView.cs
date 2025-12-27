using UnityEngine;

public class SnowView : MonoBehaviour
{
    // 一旦、配列の状態は以下のようになる
    // 0: 最初の状態、パンチが足りない状態
    // 1: ちょうどいい状態
    // 2: 穴が空きすぎた状態
    [SerializeField] private Transform[] m_snowRenderers;

    public void Initialize()
    {
        m_snowRenderers[0].gameObject.SetActive(true);
        for (var i = 1; i < m_snowRenderers.Length; i++)
        {
            m_snowRenderers[i].gameObject.SetActive(false);
        }
    }

    public void SetUnderChargeState()
    {
        m_snowRenderers[0].gameObject.SetActive(true);
        m_snowRenderers[1].gameObject.SetActive(false);
        m_snowRenderers[2].gameObject.SetActive(false);
    }

    public void SetJustState()
    {
        m_snowRenderers[0].gameObject.SetActive(false);
        m_snowRenderers[1].gameObject.SetActive(true);
        m_snowRenderers[2].gameObject.SetActive(false);
    }

    public void SetOverChargeState()
    {
        m_snowRenderers[0].gameObject.SetActive(false);
        m_snowRenderers[1].gameObject.SetActive(false);
        m_snowRenderers[2].gameObject.SetActive(true);
    }
}
