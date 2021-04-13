using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinState : State
{
    public WinState(StateMachine stateMachine) : base(stateMachine) {}
    public override IEnumerator Start()
    {
        _stateMachine.winWindow.SetActive(true);
        Camera.main.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(15);
        SceneManager.LoadSceneAsync(0);
    }
}
