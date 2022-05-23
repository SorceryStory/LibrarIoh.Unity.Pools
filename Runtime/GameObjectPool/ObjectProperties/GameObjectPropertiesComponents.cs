using SorceressSpell.LibrarIoh.Collections;
using System.Collections.Generic;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class GameObjectPropertiesComponents : IPoolObjectProperties<GameObjectPoolObject>
    {
        #region Fields

        public readonly List<ComponentProperties> ComponentProperties;

        #endregion Fields

        #region Constructors

        public GameObjectPropertiesComponents()
        {
            ComponentProperties = new List<ComponentProperties>();
        }

        #endregion Constructors

        #region Methods

        public void ApplyTo(GameObjectPoolObject poolObject)
        {
            foreach (ComponentProperties componentProperty in ComponentProperties)
            {
                componentProperty.ApplyTo(poolObject.GameObject);
            }
        }

        #endregion Methods
    }
}
