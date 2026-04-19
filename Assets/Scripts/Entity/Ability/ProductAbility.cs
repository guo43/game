using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductAbility : MonoBehaviour, IAbility
{
    private EntityController _entity;

    public GameObject productPrefab;
    public float productionTime = 5f;
    private Queue<EntityController> productQueue = new Queue<EntityController>();

    private bool isShowProcessBar = false;
    private float currentCoolTime = 0;

    public void Initialize(EntityController entity)
    {
        _entity = entity;

        currentCoolTime = productionTime;
    }

    public void AddProductTask()
    {
        GameObject product = GameObject.Instantiate(productPrefab, _entity.transform.position, Quaternion.identity);
        product.gameObject.SetActive(false);
        productQueue.Enqueue(product.GetComponent<EntityController>());
    }

    public void Update()
    {
        if (productQueue.Count > 0)
        {
            if (!isShowProcessBar)
            {
                isShowProcessBar = true;
                _entity.processBar.gameObject.SetActive(true);
            }

            currentCoolTime -= Time.deltaTime;
            if (currentCoolTime < 0)
            {
                RemoveProductTask();
                currentCoolTime = productionTime;
            }

            _entity.processBar.UpdateProcess(PercentTime);
        }

        if (isShowProcessBar && productQueue.Count <= 0)
        {
            isShowProcessBar = false;
            _entity.processBar.gameObject.SetActive(false);
        }
    }

    public void RemoveProductTask()
    {
        EntityController go = productQueue.Dequeue();
        go.gameObject.SetActive(true);
        go.GetAbility<MoveAbility>().Move(_entity.transform.position + transform.forward * 8f);
    }

    public float PercentTime
    {
        get
        {
            if (productQueue.Count == 0)
            {
                return 0f;
            }
            return Mathf.Clamp01(currentCoolTime / productionTime);
        }
    }
}
