using System;
using TinyIoC;

namespace IoCSample.Droid
{
public class IoCViewFactory : ViewFactory.ViewFactory.ViewFactory
{
    private readonly TinyIoCContainer _container;

    public IoCViewFactory(TinyIoCContainer container)
    {
        _container = container;
    }

    protected override object CreateViewModelInstance(Type viewModelType)
    {
        return _container.Resolve(viewModelType);
    }
}
}