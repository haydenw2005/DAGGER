using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TimeTickSystem : MonoBehaviour
{
    public class OnTickEventArgs : EventArgs {
        public int tick;
    }

    public static event EventHandler<OnTickEventArgs> OnTick;
    
    public float tick_max = .2f;
    private int tick;
    private float tickTimer;

    private void Awake() {
        tick = 0;
    }

    private void Update() {
        tickTimer += Time.deltaTime;
        if (tickTimer >= tick_max) {
            tickTimer -= tick_max;
            tick++;
            if (OnTick != null) OnTick(this, new OnTickEventArgs { tick = tick });
        }
        

    }

}
