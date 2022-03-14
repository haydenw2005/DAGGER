using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";
    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;
    public Transform playerAxis;

    // Update is called once per frame
    //Code from https://www.youtube.com/watch?v=_yf5vzZ2sYE
    void Update()
    {
      if(_selection != null)
      {
        var selectionRenderer  = _selection.GetComponent<Renderer>();
        selectionRenderer.material = defaultMaterial;
        _selection = null;
      }
      RaycastHit hit;
      if(Physics.Raycast(playerAxis.transform.position, playerAxis.transform.forward, out hit))
      {
        var selection = hit.transform;
        if(selection.CompareTag(selectableTag))
        {
          var selectionRenderer = selection.GetComponent<Renderer>();
          if(selectionRenderer != null)
          {
            selectionRenderer.material = highlightMaterial;
          }
          _selection = selection;
        }
      }
    }
}
