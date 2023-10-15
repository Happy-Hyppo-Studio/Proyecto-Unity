using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling
{
    private readonly HashSet<RecyclableObject> _instantiate;
    private Queue<RecyclableObject> _colectorList;

    private RecyclableObject _colector;


    public ObjectPooling(RecyclableObject colector)
    {
        _colector = colector;
    }

    public void Init()
    {
        Debug.Log("hola mundo");

        _colectorList = new Queue<RecyclableObject>(40);
    }

    public void AddColector()
    {
        //Si la queue de reciclaje está vacia crea uno y lo mete en cola

        if (_colectorList.Count == 0)
        {
            var instance = InstantiateColector();
            instance.gameObject.SetActive(true);
            _colectorList.Enqueue(instance);
        }

        //Si hay en la cola se spawnea uno ya creado (habrá que hacer que compruebe el tipo

        else
        {
            Spawn<Colector>();
        }
    }

    private RecyclableObject InstantiateColector()
    {
        var instance = Object.Instantiate(_colector);
        instance.Configure(this);
        return instance;
    }

    private RecyclableObject GetInstance()
    {
        if (_colectorList.Count > 0)
        {
            return _colectorList.Dequeue();
        }

        return null;
    }

    public T Spawn<T>()
    {
        var recyclableObject = GetInstance();
        _instantiate.Add(recyclableObject);
        recyclableObject.gameObject.SetActive(true);
        recyclableObject.Init();
        return recyclableObject.GetComponent<T>();
    }

    public void RecycleGameObject(RecyclableObject gameObjectToRecycle)
    {
        var wasInstantiated = _instantiate.Remove(gameObjectToRecycle);


        gameObjectToRecycle.gameObject.SetActive(false);
        gameObjectToRecycle.Release();
        _colectorList.Enqueue(gameObjectToRecycle);
    }
}
