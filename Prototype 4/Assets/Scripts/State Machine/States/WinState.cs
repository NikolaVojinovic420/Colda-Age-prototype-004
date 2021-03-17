using System.Collections;
using UnityEngine.SceneManagement;

internal class WinState : State
{
    public WinState(StateMachine stateMachine) : base(stateMachine) {}
    public override IEnumerator Start()
    {
        SceneManager.LoadSceneAsync(0);
        yield break;
    }
}
