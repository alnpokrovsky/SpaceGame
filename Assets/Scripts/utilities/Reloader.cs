using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reloader {
    private float reloadTime;
    private float timeout;

    public Reloader(float timeout) {
        this.timeout = timeout;
    }
    
    public bool Ready {
        get { return Time.time > reloadTime; }
    }

    public void Shot() {
        reloadTime = Time.time + timeout;
    }
}
    