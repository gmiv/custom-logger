# Unity Usage

```csharp
using UnityEngine;

public class LoggerTest : MonoBehaviour
{
    void Start()
    {
        // Testing different log types
        CustomLogger.Log("This is an informational message.");
        CustomLogger.Warn("This is a warning message.");
        CustomLogger.Error("This is an error message.");
    }

    void Update()
    {
        // Example: Log a message when the space bar is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CustomLogger.Log("Space bar pressed!");
        }
    }
}
```