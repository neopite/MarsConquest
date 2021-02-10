using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourcePanelController : MonoBehaviour
    {
        [SerializeField]private List<ResourceType> _resourceTypes;
        [SerializeField]private List<GameObject> _resourcesQuantity;
        
        private void Start()
        {
            GameEvents.Instance.OnReceiveResource += SetNewQuantity;
        }

        public void SetNewQuantity( uint newQuantity,ResourceType resourceType)
        {
            int index = _resourceTypes.IndexOf(resourceType);
            TextMeshProUGUI textMeshProUGUIComponent = _resourcesQuantity[index].GetComponent<TextMeshProUGUI>();
            int currentQuantity = Int32.Parse(textMeshProUGUIComponent.text);
            textMeshProUGUIComponent.SetText((newQuantity + currentQuantity).ToString());
        }
    }
}