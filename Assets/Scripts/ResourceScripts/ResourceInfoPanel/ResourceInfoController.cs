using System;
using TMPro;
using UnityEngine;

namespace DefaultNamespace
{
    public class ResourceInfoController : MonoBehaviour
    {
        private GameObject _resourceWindow;
        private IResource _resourceData;
        private TextMeshProUGUI _oreQuantity;
        private TextMeshProUGUI _oreName;
        private void Start()
        {
            _resourceWindow = GameObject.Find("PopupCanvas");
            _resourceData = GetComponent<BaseResource>();
            _oreName = _resourceWindow.transform.Find("Ore_name").GetComponent <TextMeshProUGUI>();
            _oreQuantity = _resourceWindow.transform.Find("Quantity").GetComponent <TextMeshProUGUI>();
            _oreName.SetText(_resourceData.ResourceType.ToString());
            _oreQuantity.SetText(_resourceData.Amount.ToString());
            GameEvents.Instance.OnResourceDisplayOnPupupPanel += ChangeResourceQuantity;
                _resourceWindow.SetActive(false);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (string.Equals(other.tag, "Player"))
            {
                _resourceWindow.SetActive(true);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            _resourceWindow.SetActive(false);
        }

        public void ChangeResourceQuantity(int newQuantity)
        {
            _oreQuantity.SetText(_resourceData.Amount.ToString());
        }

        private void OnDestroy()
        {
            GameEvents.Instance.OnResourceDisplayOnPupupPanel -= ChangeResourceQuantity;
        }
    }
}