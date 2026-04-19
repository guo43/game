using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityController : MonoBehaviour
{
    public HealthBarItem healthBar;
    public ProcessBarItem processBar;

    private Dictionary<Type, IAbility> abilitys;

    private void Awake()
    {
        healthBar.Initialize();
        processBar.Initialize();

        InitAbility();
    }

    private void InitAbility()
    {
        IAbility[] list = GetComponents<IAbility>().ToArray();
        abilitys = new Dictionary<Type, IAbility>(list.Length);
        for (int i = 0; i < list.Length; i++)
        {
            IAbility ability = list[i];
            abilitys[ability.GetType()] = list[i];
            list[i].Initialize(this);
        }
    }

    public T GetAbility<T>() where T : IAbility
    {
        if (abilitys.TryGetValue(typeof(T), out IAbility ability))
        {
            return (T)ability;
        }

        return default(T);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetAbility<ProductAbility>()?.AddProductTask();
        };
    }
}
