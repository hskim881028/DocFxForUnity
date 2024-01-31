using System;
using System.Collections.Generic;
using V8.UI.Runtime.Factory;

namespace V8.UI.Runtime.Provider
{
    internal abstract class FactoryProvider<T> : IFactoryProvider<T> where T : IFactory
    {
        private readonly Dictionary<string, T> _factories = new();

        public T GetFactory(string type)
        {
            if (!_factories.TryGetValue(type, out var factory))
            {
                throw new NotImplementedException($"Factory for type {type} is not implemented.");
            }

            return factory;
        }

        protected void RegisterFactory(T factory)
        {
            _factories[factory.Type] = factory;
        }
    }
}