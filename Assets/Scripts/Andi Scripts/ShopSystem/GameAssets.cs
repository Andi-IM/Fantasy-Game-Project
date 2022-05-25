using UnityEngine;

/**
 * ---------------------- Code Monkey --------------------------------
 *
 * Get it from unitycodemonkey.com
 * -------------------------------------------------------------------
 */
public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if (_i == null) _i = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return _i;
        }
    }

    public Sprite s_static;
    public Sprite s_consumable;
}