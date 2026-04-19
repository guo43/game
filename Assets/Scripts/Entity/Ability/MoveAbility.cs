using System.Collections;
using UnityEngine;

public class MoveAbility : MonoBehaviour, IAbility
{
    private EntityController _entity;
    private Coroutine moveCoroutine;

    public void Initialize(EntityController entity)
    {
        _entity = entity;
    }

    public void Move(Vector3 targetPos)
    {
        if (moveCoroutine != null)
        {
            _entity.StopCoroutine(moveCoroutine);
        }

        _entity.StartCoroutine(_Move(targetPos));
    }

    private IEnumerator _Move(Vector3 targetPos)
    {
        while (Vector3.Distance(_entity.transform.position, targetPos) > 0.1f)
        {
            _entity.transform.position = Vector3.MoveTowards(_entity.transform.position, targetPos, Time.deltaTime * 5f);
            yield return null;
        }
    }
}
