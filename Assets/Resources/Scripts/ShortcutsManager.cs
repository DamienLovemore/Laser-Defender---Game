using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShortcutsManager : MonoBehaviour
{
    void OnShortcutsHandle(InputValue value)
    {
        //If the user pressed Esc the game should end
        if (Keyboard.current.escapeKey.isPressed)
        {
            Application.Quit();
        }
        //If the user pressed f11 the game should toggle
        //its screen mode
        else if (Keyboard.current.f11Key.isPressed)
        {
            FullScreenMode currentScreenMode = Screen.fullScreenMode;

            //If it is at fullscreen it should toggle to windowed mode
            if ((currentScreenMode != FullScreenMode.Windowed) && (currentScreenMode != FullScreenMode.MaximizedWindow))
            {
                Screen.fullScreenMode = FullScreenMode.Windowed;
            }
            //If it is not at fullscreen mode, then it is at windowed mode.
            //So it should switch to fullscreen mode
            else
            {
                Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
            }
        }
    }
}
