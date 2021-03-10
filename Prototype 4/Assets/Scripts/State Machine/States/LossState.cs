﻿using System.Collections;
using UnityEngine.SceneManagement;

internal class LossState : State
{
    public LossState(StateMachine stateMachine) : base(stateMachine)
    {
    }
    public override IEnumerator Start()
    {
        SceneManager.LoadSceneAsync(0);
        yield break;
    }
}