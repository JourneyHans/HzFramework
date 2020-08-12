using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    public FSM<T> FSM;
    public virtual int StateType() { return -1; }

    public virtual bool BeforeEnterCheck(T owner) { return true; }
    public virtual void Enter(T obj, object param = null) { }
    public virtual void DoUpdate(T obj, float deltaTime) { }
    public virtual void Exit(T owner) { }
}

public class FSM<T>
{
    public T Owner;
    public State<T> CurrentState { get; private set; }
    public State<T> PreviousState { get; private set; }

    private readonly Dictionary<int, State<T>> _stateMap = new Dictionary<int, State<T>>();

    public static FSM<T> Create(T owner)
    {
        FSM<T> fsm = new FSM<T>();
        fsm.Owner = owner;
        return fsm;
    }

    public void Register(State<T> state)
    {
        int stateType = state.StateType();
        if (_stateMap.ContainsKey(stateType))
        {
            Debug.LogError($"[FSM:Register] type {stateType} is existed in FSM");
        }
        _stateMap[stateType] = state;
        state.FSM = this;
    }

    public void DoUpdate(float deltaTime)
    {
        CurrentState?.DoUpdate(Owner, deltaTime);
    }

    public void ChangeState(int stateType, bool force = false)
    {
        if (_stateMap[stateType] == null || !_stateMap[stateType].BeforeEnterCheck(Owner))
        {
            return;
        }

        if (CurrentState != null && CurrentState != _stateMap[stateType])
        {
            CurrentState.Exit(Owner);
            PreviousState = CurrentState;
        }

        if (CurrentState != _stateMap[stateType] || force)
        {
            CurrentState = _stateMap[stateType];
            CurrentState.Enter(Owner);
        }
    }

    public void Exit()
    {
        if (CurrentState == null)
        {
            return;
        }

        CurrentState.Exit(Owner);
        CurrentState = null;
        PreviousState = null;
    }
}
