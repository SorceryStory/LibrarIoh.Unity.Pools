using SorceressSpell.LibrarIoh.Collections;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class GameObjectPool<TObject> : Pool<TObject>
        where TObject : GameObjectPoolObject, new()
    {
        #region Fields

        private readonly string _objectBaseName;
        private readonly GameObject _objectPrefab;
        private readonly GameObject _poolGameObject;

        #endregion Fields

        #region Constructors

        public GameObjectPool(string poolName, Transform parentTransform, GameObject objectPrefab, string objectBaseName, int preAllocate)
            : base()
        {
            _poolGameObject = new GameObject(poolName);
            _poolGameObject.transform.SetParent(parentTransform, true);

            _objectBaseName = objectBaseName;
            _objectPrefab = objectPrefab;

            Allocate(preAllocate);
        }

        public GameObjectPool(GameObject poolGameObject, GameObject objectPrefab, string objectBaseName, int preAllocate)
            : base()
        {
            _poolGameObject = poolGameObject;

            _objectBaseName = objectBaseName;
            _objectPrefab = objectPrefab;

            Allocate(preAllocate);
        }

        #endregion Constructors

        #region Methods

        public virtual void LateUpdate(float deltaTime)
        {
            PoolCollection.RemoveAll(IsNullGameObject);

            foreach (TObject poolObject in PoolCollection)
            {
                poolObject.LateUpdate(deltaTime);
            }
        }

        protected override TObject Pool_CreatePoolObject()
        {
            TObject poolObject = new TObject();
            poolObject.SetPrefab(_objectPrefab, _poolGameObject != null ? _poolGameObject.transform : null);

            return poolObject;
        }

        protected override string Pool_GetNewObjectName()
        {
            return string.Format(PoolsStrings.PoolObjectNamingConvention, _objectBaseName, PoolCollection.Count.ToString());
        }

        protected override void Pool_PostDestroyAll()
        {
            GameObject.Destroy(_poolGameObject);
        }

        private bool IsNullGameObject(TObject obj)
        {
            return obj.GameObject == null;
        }

        #endregion Methods
    }
}
