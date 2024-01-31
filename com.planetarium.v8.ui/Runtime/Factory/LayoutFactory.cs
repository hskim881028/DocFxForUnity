using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;
using V8.UI.Elements.Basic;
using V8.UI.Configuration;
using V8.UI.Runtime.Configuration;
using V8.UI.Runtime.Factory.Extensions;

namespace V8.UI.Runtime.Factory
{
    internal class LayoutFactory : ComponentFactory<Layout>
    {
        private readonly ElementComponentFactory _elementComponentFactory;

        public LayoutFactory(ElementComponentFactory elementComponentFactory)
        {
            _elementComponentFactory = elementComponentFactory;
        }

        protected override RectTransform CreateTyped(Layout element, RectTransform parent)
        {
            var component = _elementComponentFactory.Create(element, parent);
            var go = new GameObject(element.Type);
            var rt = go.AddComponent<RectTransform>();
            rt.ResetForChild(component);

            var glg = go.AddComponent<GridLayoutGroup>();
            ConfigureLayout(element, glg);
            return rt;
        }

        private void ConfigureLayout(Layout element, GridLayoutGroup glg)
        {
            UpdateCornerMode(glg, element.CornerMode);
            UpdateAxisMode(glg, element.AxisMode);
            UpdateChildAlignment(glg, element.ChildAlignmentMode);
            UpdateChildConstraint(glg, element.ChildConstraintMode);
            UpdatePadding(glg, element.Padding);
            UpdateChildSize(glg, element.ChildSize);
            UpdateSpacing(glg, element.Spacing);
            UpdateChildConstraintCount(glg, element.ChildConstraintCount);

            element.PropertyChanged += (_, e) => OnPropertyChanged(e, glg, element);
        }

        private void UpdateCornerMode(GridLayoutGroup glg, CornerMode mode)
        {
            glg.startCorner = UnityEnumMapper.ToCorner(mode);
        }

        private void UpdateAxisMode(GridLayoutGroup glg, AxisMode mode)
        {
            glg.startAxis = UnityEnumMapper.ToAxis(mode);
        }
        
        private void UpdateChildAlignment(GridLayoutGroup glg, AlignmentMode mode)
        {
            glg.childAlignment = UnityEnumMapper.ToTextAnchor(mode);
        }

        private void UpdateChildConstraint(GridLayoutGroup glg, ConstraintMode mode)
        {
            glg.constraint = UnityEnumMapper.ToConstraint(mode);
        }

        private void UpdatePadding(GridLayoutGroup glg, Padding padding)
        {
            glg.padding = new RectOffset(padding.Left, padding.Right, padding.Top, padding.Bottom);
        }

        private void UpdateChildSize(GridLayoutGroup glg, Vector2 size)
        {
            glg.cellSize = size;
        }

        private void UpdateSpacing(GridLayoutGroup glg, Vector2 spacing)
        {
            glg.spacing = spacing;
        }

        private void UpdateChildConstraintCount(GridLayoutGroup glg, int childConstraintCount)
        {
            glg.constraintCount = childConstraintCount;
        }

        private void OnPropertyChanged(PropertyChangedEventArgs e, GridLayoutGroup glg, Layout element)
        {
            switch (e.PropertyName)
            {
                case nameof(Layout.CornerMode):
                    UpdateCornerMode(glg, element.CornerMode);
                    break;
                case nameof(Layout.AxisMode):
                    UpdateAxisMode(glg, element.AxisMode);
                    break;
                case nameof(Layout.ChildAlignmentMode):
                    UpdateChildAlignment(glg, element.ChildAlignmentMode);
                    break;
                case nameof(Layout.ChildConstraintMode):
                    UpdateChildConstraint(glg, element.ChildConstraintMode);
                    break;
                case nameof(Layout.Padding):
                    UpdatePadding(glg, element.Padding);
                    break;
                case nameof(Layout.ChildSize):
                    UpdateChildSize(glg, element.ChildSize);
                    break;
                case nameof(Layout.Spacing):
                    UpdateSpacing(glg, element.Spacing);
                    break;
                case nameof(Layout.ChildConstraintCount):
                    UpdateChildConstraintCount(glg, element.ChildConstraintCount);
                    break;
            }
        }
    }
}