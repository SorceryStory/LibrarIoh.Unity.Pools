using SorceressSpell.LibrarIoh.Collections;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class GameObjectPropertiesPrefab : IPoolObjectProperties<GameObjectPoolObject>
    {
        #region Fields

        public GameObject Prefab;

        #endregion Fields

        #region Methods

        public void ApplyTo(GameObjectPoolObject poolObject)
        {
            poolObject.SetPrefab(Prefab);
        }

        #endregion Methods
    }
}
