using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Caliburn.Light
{
    /// <summary>
    /// A simple IoC container.
    /// </summary>
    public class SimpleContainer : IServiceProvider
    {
        private static readonly TypeInfo DelegateType = typeof(Delegate).GetTypeInfo();
        private static readonly TypeInfo EnumerableType = typeof(IEnumerable).GetTypeInfo();

        private readonly List<ContainerEntry> _entries;

        /// <summary>
        /// Initializes a new instance of the <see cref="SimpleContainer" /> class.
        /// </summary>
        public SimpleContainer()
        {
            _entries = new List<ContainerEntry>();

            RegisterPerRequest(c => c);
            RegisterPerRequest<IServiceProvider>(c => c);
        }

        private SimpleContainer(IEnumerable<ContainerEntry> entries)
        {
            _entries = new List<ContainerEntry>(entries);
        }

        /// <summary>
        /// Creates a child container.
        /// </summary>
        /// <returns>A new container.</returns>
        public SimpleContainer CreateChildContainer()
        {
            return new SimpleContainer(_entries);
        }

        /// <summary>
        /// Determines if a handler for the service/key has previously been registered.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="key">The key.</param>
        /// <returns>True if a handler is registered; false otherwise.</returns>
        public bool IsRegistered(Type service, string key = null)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            return _entries.Any(x => x.Service == service && x.Key == key);
        }

        /// <summary>
        /// Determines if a handler for the service/key has previously been registered.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>True if a handler is registered; false otherwise.</returns>
        public bool IsRegistered<TService>(string key = null)
        {
            return IsRegistered(typeof(TService), key);
        }

        /// <summary>
        /// Registers the class so that it is created once, on first request, and the same instance is returned to all requestors thereafter.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        public void RegisterSingleton(Type service, Type implementation, string key = null)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));
            if (implementation is null)
                throw new ArgumentNullException(nameof(implementation));

            object singleton = null;
            GetOrCreateEntry(service, key).Add(c => singleton ?? (singleton = c.BuildInstance(implementation)));
        }

        /// <summary>
        /// Registers the class so that it is created once, on first request, and the same instance is returned to all requestors thereafter.
        /// </summary>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key.</param>
        public void RegisterSingleton<TImplementation>(string key = null)
        {
            RegisterSingleton(typeof(TImplementation), typeof(TImplementation), key);
        }

        /// <summary>
        /// Registers the class so that it is created once, on first request, and the same instance is returned to all requestors thereafter.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key.</param>
        public void RegisterSingleton<TService, TImplementation>(string key = null)
            where TImplementation : TService
        {
            RegisterSingleton(typeof(TService), typeof(TImplementation), key);
        }

        /// <summary>
        /// Registers the class so that it is created once, on first request, and the same instance is returned to all requestors thereafter.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="key">The key.</param>
        public void RegisterSingleton<TService>(Func<SimpleContainer, TService> handler, string key = null)
        {
            if (handler is null)
                throw new ArgumentNullException(nameof(handler));

            object singleton = null;
            GetOrCreateEntry(typeof(TService), key).Add(c => singleton ?? (singleton = handler(c)));
        }

        /// <summary>
        /// Registers an instance with the container.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        public void RegisterInstance(Type service, object instance, string key = null)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            GetOrCreateEntry(service, key).Add(_ => instance);
        }

        /// <summary>
        /// Registers an instance with the container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <param name="key">The key.</param>
        public void RegisterInstance<TService>(TService instance, string key = null)
        {
            RegisterInstance(typeof(TService), instance, key);
        }

        /// <summary>
        /// Registers the class so that a new instance is created on each request.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="key">The key.</param>
        public void RegisterPerRequest(Type service, Type implementation, string key = null)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));
            if (implementation is null)
                throw new ArgumentNullException(nameof(implementation));

            GetOrCreateEntry(service, key).Add(c => c.BuildInstance(implementation));
        }

        /// <summary>
        /// Registers the class so that a new instance is created on each request.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="key">The key.</param>
        public void RegisterPerRequest<TService>(string key = null)
        {
            RegisterPerRequest<TService, TService>(key);
        }

        /// <summary>
        /// Registers the class so that a new instance is created on each request.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <typeparam name="TImplementation">The type of the implementation.</typeparam>
        /// <param name="key">The key.</param>
        public void RegisterPerRequest<TService, TImplementation>(string key = null)
            where TImplementation : TService
        {
            RegisterPerRequest(typeof(TService), typeof(TImplementation), key);
        }

        /// <summary>
        /// Registers a custom handler for serving requests from the container.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="handler">The handler.</param>
        /// <param name="key">The key.</param>
        public void RegisterPerRequest(Type service, Func<SimpleContainer, object> handler, string key = null)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));
            if (handler is null)
                throw new ArgumentNullException(nameof(handler));

            GetOrCreateEntry(service, key).Add(handler);
        }

        /// <summary>
        /// Registers a custom handler for serving requests from the container.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="handler">The handler.</param>
        /// <param name="key">The key.</param>
        public void RegisterPerRequest<TService>(Func<SimpleContainer, TService> handler, string key = null)
        {
            if (handler is null)
                throw new ArgumentNullException(nameof(handler));

            GetOrCreateEntry(typeof(TService), key).Add(c => handler(c));
        }

        /// <summary>
        /// Unregisters any handlers for the service/key that have previously been registered.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="key">The key.</param>
        /// <returns>true if handler is successfully removed; otherwise, false.</returns>
        public bool UnregisterHandler(Type service, string key = null)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            var entry = _entries.Find(x => x.Service == service && x.Key == key);
            if (entry is null)
                return false;
            return _entries.Remove(entry);
        }

        /// <summary>
        /// Unregisters any handlers for the service/key that have previously been registered.
        /// </summary>
        /// <typeparam name="TService">The of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>true if handler is successfully removed; otherwise, false.</returns>
        public bool UnregisterHandler<TService>(string key = null)
        {
            return UnregisterHandler(typeof(TService), key);
        }

        object IServiceProvider.GetService(Type serviceType)
        {
            return GetInstance(serviceType, null);
        }

        /// <summary>
        /// Requests an instance.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="key">The key.</param>
        /// <returns>The instance.</returns>
        public TService GetInstance<TService>(string key = null)
        {
            return (TService)GetInstance(typeof(TService), key);
        }

        /// <summary>
        /// Requests an instance.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <param name="key">The key.</param>
        /// <returns>The instance.</returns>
        public object GetInstance(Type service, string key = null)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            var entry = _entries.Find(x => x.Service == service && x.Key == key) ?? _entries.Find(x => x.Service == service);
            if (entry is object)
            {
                if (entry.Count != 1)
                    throw new InvalidOperationException(string.Format("Found multiple registrations for type '{0}' and key {1}.", service, key));

                return entry[0](this);
            }

            var serviceType = service.GetTypeInfo();

            if (serviceType.IsGenericType && DelegateType.IsAssignableFrom(serviceType))
            {
                var typeToCreate = service.GenericTypeArguments[0];
                var factoryFactoryType = typeof(FactoryFactory<>).MakeGenericType(typeToCreate);
                var factoryFactoryHost = Activator.CreateInstance(factoryFactoryType);
                var factoryFactoryMethod = factoryFactoryType.GetRuntimeMethod("Create", new[] { typeof(SimpleContainer), typeof(string) });
                return factoryFactoryMethod.Invoke(factoryFactoryHost, new object[] { this, key });
            }

            if (serviceType.IsGenericType && EnumerableType.IsAssignableFrom(serviceType))
            {
                if (key is object)
                    throw new InvalidOperationException(string.Format("Requesting type '{0}' with key {1} is not supported.", service, key));

                var listType = service.GenericTypeArguments[0];
                var instances = GetAllInstances(listType);
                var array = Array.CreateInstance(listType, instances.Length);

                for (var i = 0; i < array.Length; i++)
                {
                    array.SetValue(instances[i], i);
                }

                return array;
            }

            return (serviceType.IsValueType) ? Activator.CreateInstance(service) : null;
        }

        /// <summary>
        /// Gets all instances of a particular type.
        /// </summary>
        /// <typeparam name="TService">The type to resolve.</typeparam>
        /// <returns>The resolved instances.</returns>
        public TService[] GetAllInstances<TService>()
        {
            var service = typeof(TService);

            var instances = _entries
                .Where(x => x.Service == service)
                .SelectMany(e => e.Select(x => (TService)x(this)))
                .ToArray();

            return instances;
        }

        /// <summary>
        /// Requests all instances of a given type.
        /// </summary>
        /// <param name="service">The service.</param>
        /// <returns>All the instances or an empty enumerable if none are found.</returns>
        public object[] GetAllInstances(Type service)
        {
            if (service is null)
                throw new ArgumentNullException(nameof(service));

            var instances = _entries
                .Where(x => x.Service == service)
                .SelectMany(e => e.Select(x => x(this)))
                .ToArray();

            return instances;
        }

        private ContainerEntry GetOrCreateEntry(Type service, string key)
        {
            var entry = _entries.Find(x => x.Service == service && x.Key == key);
            if (entry is null)
            {
                entry = new ContainerEntry { Service = service, Key = key };
                _entries.Add(entry);
            }

            return entry;
        }

        /// <summary>
        /// Actually does the work of creating the instance and satisfying it's constructor dependencies.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>The build instance.</returns>
        protected object BuildInstance(Type type)
        {
            var constructor = type.GetTypeInfo().DeclaredConstructors
                .OrderByDescending(c => c.GetParameters().Length)
                .FirstOrDefault(c => c.IsPublic);

            if (constructor is null)
                throw new InvalidOperationException(string.Format("Type '{0}' has no public constructor.", type));

            var args = constructor.GetParameters()
                .Select(info => GetInstance(info.ParameterType, null))
                .ToArray();

            return ActivateInstance(type, args);
        }

        /// <summary>
        /// Creates an instance of the type with the specified constructor arguments.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="args">The constructor arguments.</param>
        /// <returns>The created instance.</returns>
        protected virtual object ActivateInstance(Type type, object[] args)
        {
            return (args.Length > 0) ? Activator.CreateInstance(type, args) : Activator.CreateInstance(type);
        }

        private sealed class ContainerEntry : List<Func<SimpleContainer, object>>
        {
            public string Key;
            public Type Service;
        }

        private sealed class FactoryFactory<T>
        {
            public Func<T> Create(SimpleContainer container, string key)
            {
                return () => (T)container.GetInstance(typeof(T), key);
            }
        }
    }
}