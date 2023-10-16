using UnityEngine;

public class NewLog : AutoMonoBehaviour
{
    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void DebugLog(
        string message, object Object
    ) => Debug.Log(message);

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void DebugWarning(
        string message
    ) => Debug.LogWarning(message);

    [System.Diagnostics.Conditional("ENABLE_LOG")]
    public static void DebugError(
        string message
    ) => Debug.LogError(message: message);
}
