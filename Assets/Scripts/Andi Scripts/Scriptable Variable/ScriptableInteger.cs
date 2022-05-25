using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Integer", menuName = "Scriptable Variable/Integer")]
public class ScriptableInteger : ScriptableObject
{
    public int value;
    public int defaultValue;
    public bool isResetOnEnable;

    private void OnEnable()
    {
        if (isResetOnEnable)
        {
            value = defaultValue;
        }
    }

    public void Reset()
    {
        value = defaultValue;
    }
}
