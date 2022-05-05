using System;
using System.Collections;
using UnityEngine;

public static class Utility
{
    public static IEnumerator TimedEvent(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }
}
