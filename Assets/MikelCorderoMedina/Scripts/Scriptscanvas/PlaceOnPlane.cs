using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.ARFoundation;

namespace UnityEngine.XR.ARFoundation.Samples
{
    [RequireComponent(typeof(ARRaycastManager))]
    public class PlaceOnPlane : PressInputBase
    {
        [SerializeField]
        [Tooltip("Referencia al gestor de UI con prefabs y lógica")]
        public ARUIManager uiManager;  // 🔹 NUEVO

        bool m_Pressed;
        static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
        ARRaycastManager m_RaycastManager;

        protected override void Awake()
        {
            base.Awake();
            m_RaycastManager = GetComponent<ARRaycastManager>();
        }

        void Update()
        {
            if (Pointer.current == null || m_Pressed == false)
                return;

            var touchPosition = Pointer.current.position.ReadValue();

            if (m_RaycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
            {
                var hitPose = s_Hits[0].pose;

                // 🔹 En vez de usar un prefab fijo, delegamos en el UI Manager
                uiManager.InstanciarPrefab(hitPose.position);
            }
        }

        protected override void OnPress(Vector3 position) => m_Pressed = true;

        protected override void OnPressCancel() => m_Pressed = false;
    }
}
