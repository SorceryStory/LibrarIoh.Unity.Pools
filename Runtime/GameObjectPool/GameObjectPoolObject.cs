using SorceressSpell.LibrarIoh.Collections;
using UnityEngine;

namespace SorceressSpell.LibrarIoh.Unity.Pools
{
    public class GameObjectPoolObject : IPoolObject
    {
        #region Fields

        private GameObject _gameObject;

        #endregion Fields

        #region Properties

        public GameObject GameObject
        {
            get { return _gameObject; }
        }

        #endregion Properties

        #region Constructors

        public GameObjectPoolObject()
        {
            SetPrefab(null, null);
        }

        public GameObjectPoolObject(GameObject prefab, Transform parentTransform)
        {
            SetPrefab(prefab, parentTransform);
        }

        #endregion Constructors

        #region Methods

        public void Activate()
        {
            _gameObject.SetActive(true);

            GameObjectPoolObject_OnActivate();
        }

        public virtual void Deactivate()
        {
            GameObjectPoolObject_OnDeactivate();

            _gameObject.SetActive(false);
        }

        public void Destroy()
        {
            GameObjectPoolObject_OnDestroy();

            GameObject.Destroy(_gameObject);
        }

        public void Initialize(string name)
        {
            _gameObject.name = name;

            GameObjectPoolObject_OnInitialize(name);
        }

        public bool IsActive()
        {
            return _gameObject.activeSelf;
        }

        public void LateUpdate(float deltaTime)
        {
            GameObjectPoolObject_OnLateUpdate(deltaTime);
        }

        public void SetPrefab(GameObject prefab)
        {
            SetPrefab(prefab, _gameObject != null ? _gameObject.transform.parent : null);
        }

        public void SetPrefab(GameObject prefab, Transform parentTransform)
        {
            if (_gameObject != null)
            {
                GameObject.Destroy(_gameObject);
            }

            _gameObject = prefab != null ? GameObject.Instantiate(prefab) : new GameObject();
            _gameObject.transform.SetParent(parentTransform);

            GameObjectPoolObject_OnInstantiation();
        }

        public void Update(float deltaTime)
        {
            GameObjectPoolObject_OnUpdate(deltaTime);
        }

        protected virtual void GameObjectPoolObject_OnActivate()
        {
        }

        protected virtual void GameObjectPoolObject_OnDeactivate()
        {
        }

        protected virtual void GameObjectPoolObject_OnDestroy()
        {
        }

        protected virtual void GameObjectPoolObject_OnInitialize(string name)
        {
        }

        protected virtual void GameObjectPoolObject_OnInstantiation()
        {
        }

        protected virtual void GameObjectPoolObject_OnLateUpdate(float deltaTime)
        {
        }

        protected virtual void GameObjectPoolObject_OnUpdate(float deltaTime)
        {
        }

        #endregion Methods
    }
}
