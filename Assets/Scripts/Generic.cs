using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Generic : MonoBehaviour
{

    [SerializeField]
    protected MeshRenderer _meshRenderer;

    private int min = -10;
    private int max = 10;

    [SerializeField]
    protected Color defaultColor;

    [SerializeField]
    protected Color highlightedColor;

    private void Awake()
    {
        transform.localPosition = new Vector3(Random.Range(min, max), 0, Random.Range(min, max));
        _meshRenderer.material.color = defaultColor;
    }

    public virtual void HighlightItem()
    {
        _meshRenderer.material.color = highlightedColor;
    }

    public virtual void ResetItemColorToDefault()
    {
        _meshRenderer.material.color = defaultColor;
    }    
}
