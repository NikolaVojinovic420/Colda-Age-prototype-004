using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LossState : State
{
    public LossState(StateMachine stateMachine) : base(stateMachine) {}
    public override IEnumerator Start()
    {
        _stateMachine.lossWindow.SetActive(true);
        Camera.main.GetComponent<AudioSource>().Stop();
        yield return new WaitForSeconds(15);
        SceneManager.LoadSceneAsync(0);
    }
}
