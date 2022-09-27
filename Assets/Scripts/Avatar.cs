using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public abstract class Avatar : NetworkBehaviour
{
    protected Action OnUpdateAction { get; set; }
    //protected abstract FireAction fireAction { get; set; }
    [SyncVar] protected Vector3 serverPosition;
    [SyncVar] protected Quaternion serverRotation;
    protected virtual void Initiate()
    {
        OnUpdateAction += Movement;
    }
    private void Update()
    {
        OnUpdate();
    }
    private void OnUpdate()
    {
        OnUpdateAction?.Invoke();
    }
    [Command]
    protected void CmdUpdatePosition(Vector3 position)
    {
        serverPosition = position;
    }

    [Command]
    protected void CmdUpdateRotation(Quaternion rotation)
    {
        serverRotation = rotation;
    }
    public abstract void Movement();
}

