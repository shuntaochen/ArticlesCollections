using System;
using System.Collections.Generic;
using System.Linq;

namespace Demos
{
    class Program
    {
        static void Main(string[] args)
        {
            TypeManager.Instance.Register<ISample, SampeEvent>();

            TypeManager.Instance.TriggerHandler<SampeEvent>();

            Console.WriteLine("Hello World!");
        }
    }


    interface ISample { }

    class SampeEvent : ISample
    {

    }
    interface IHandler<TEvent>
    {
        void Handle(TEvent @event);
    }

    class Handler : IHandler<SampeEvent>
    {
        public void Handle(SampeEvent @event)
        {
            throw new NotImplementedException();
        }
    }


    class TypeManager
    {

        public static TypeManager Instance = new TypeManager();

        private TypeManager()
        {

        }

        private Dictionary<Type, Type> InventoryList = new Dictionary<Type, Type>();
        public void Register<TInterface, TImplementation>()
        {
            InventoryList.Add(typeof(TInterface), typeof(TImplementation));
        }

        public void TriggerHandler<TEvent>()
        {
            var handlerType = typeof(IHandler<>).MakeGenericType(typeof(TEvent));
            var @event = Activator.CreateInstance<SampeEvent>();
            var canAssign = typeof(Handler).GetInterfaces().Any(ii => ii.Name == handlerType.Name);
            var handler = Activator.CreateInstance<Handler>();
            typeof(Handler).GetMethod("Handle").Invoke(handler, new object[] { @event });
        }


    }
}
