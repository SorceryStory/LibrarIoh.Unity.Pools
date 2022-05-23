using SorceressSpell.LibrarIoh.Collections;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public abstract class ComponentProperties : IPoolObjectProperties<GameObject>
    {
        #region Fields

        public bool AddComponentIfNotPresent = true;

        #endregion Fields

        #region Methods

        public abstract void ApplyTo(GameObject gameObject);

        protected void ApplyPropertiesToComponent<TComponent>(GameObject gameObject, IPoolObjectProperties<TComponent> componentProperties)
            where TComponent : Component
        {
            TComponent component = gameObject.GetComponent<TComponent>();

            if (component == null && AddComponentIfNotPresent)
            {
                component = gameObject.AddComponent<TComponent>();
            }

            if (component != null)
            {
                componentProperties.ApplyTo(component);
            }
        }

        protected void ApplyPropertiesToComponents<TComponent>(GameObject gameObject, IPoolObjectProperties<TComponent> componentProperties)
            where TComponent : Component
        {
            TComponent[] components = gameObject.GetComponents<TComponent>();

            if (components.Length <= 0 && AddComponentIfNotPresent)
            {
                TComponent component = gameObject.AddComponent<TComponent>();
                componentProperties.ApplyTo(component);
            }
            else
            {
                foreach (TComponent component in components)
                {
                    if (component != null)
                    {
                        componentProperties.ApplyTo(component);
                    }
                }
            }
        }

        #endregion Methods
    }
}
