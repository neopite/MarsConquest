using System;
using System.Text;
using TMPro;
using UnityEngine;

namespace InteractionWithWorld
{
    public class PlayerInteraction : MonoBehaviour
    {
        [SerializeField]private float _interactionDistance = 2f;
        public GameObject TextFieldGameObject;
        private TextMeshProUGUI _textMeshProUGUI;
        private void Start()
        {
            _textMeshProUGUI = TextFieldGameObject.GetComponent<TextMeshProUGUI>();
        }

        private void FixedUpdate()
        {
            RaycastHit raycastHit ;
            Debug.DrawRay(transform.position,transform.forward*_interactionDistance);
            if (Physics.Raycast(transform.position, transform.forward, out raycastHit,_interactionDistance))
            {
                Interactable interaction = raycastHit.collider.GetComponent<Interactable>();
                ActivateTextField();
                if (interaction != null)
                {
                    _textMeshProUGUI.SetText(new StringBuilder(interaction.GetDescription()));
                    HandleInteraction(interaction);
                }
            }else _textMeshProUGUI.SetText("");
        }

        private void ActivateTextField()
        { 
            TextFieldGameObject.SetActive(true);
        }

        private void DeactivateTextField()
        {
            TextFieldGameObject.SetActive(false);
        }
        
        private void HandleInteraction(Interactable interactable)
        {
            Interactable.InteractionType interactionType = interactable.InteractType;
            switch (interactionType)
            {
                case Interactable.InteractionType.Press : 
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interactable.Interact();
                    }
                    break;
                case Interactable.InteractionType.Hold :
                    if (Input.GetKey(KeyCode.T))
                    {
                        interactable.Interact();
                    }
                    break;
                    ;
                    default: throw new Exception("Not such Interaction Type as mentiond");
            }
        }
    }
}