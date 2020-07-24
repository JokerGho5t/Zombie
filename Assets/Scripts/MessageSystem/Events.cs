using System;
using System.Numerics;
using UnityEngine.Events;

namespace JokerGho5t.CustomEvents
{
    [Serializable]
    public class StringEvent : UnityEvent<string> { }

    [Serializable]
    public class HitEvent : UnityEvent<Vector3, Quaternion, float> { }
}
