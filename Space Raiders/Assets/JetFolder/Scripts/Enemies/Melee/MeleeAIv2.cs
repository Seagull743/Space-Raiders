using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Active.Core;
using static Active.Status;

public class MeleeAIv2 : UGig
{
    override public status Step() => Eval(
        Attack())

    void Update()
    {
        state = Attack() || Defend() || Retreat();
        if (!state.running)
        {
            enabled = false;
        }
    }

    status Attack()
    {

    }
}
