using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RecyclableObject : MonoBehaviour
{
    private ObjectPooling _controler;


    internal void Configure(ObjectPooling controler)
    {
        _controler = controler;
    }

    public void Recycle()
    {
        _controler.RecycleGameObject(this);
    }

    internal abstract void Init();

    internal abstract void Release();
}
