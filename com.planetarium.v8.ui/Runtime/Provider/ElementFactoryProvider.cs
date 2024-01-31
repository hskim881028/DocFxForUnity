using V8.UI.Elements.Basic;
using V8.UI.Runtime.Factory;

namespace V8.UI.Runtime.Provider
{
    internal class ElementFactoryProvider : FactoryProvider<IElementFactory>
    {
        public ElementFactoryProvider()
        {
            RegisterFactory(new ElementFactory<Element>());
            RegisterFactory(new ElementFactory<Label>());
            RegisterFactory(new ElementFactory<Image>());
            RegisterFactory(new ElementFactory<Layout>());
        }
    }
}