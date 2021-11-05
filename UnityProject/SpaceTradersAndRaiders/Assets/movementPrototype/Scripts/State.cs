using System.Collections;
using UnityEngine;

public abstract class State 
{
    public GameManager _system;
    public State(GameManager system)
    {
        _system = system;

    }
    public virtual IEnumerator Start()
    {
        yield break;
    }

    public virtual IEnumerator setupUniverse()
    {
        yield break;
    }
    public virtual IEnumerator Player1Turn()
    {
        yield break;
    }
    public virtual IEnumerator Player2Turn()
    {
        yield break;
    }

    public virtual IEnumerator Combat(GameObject attacker, GameObject defender)
    {
        yield break;
    }
}

