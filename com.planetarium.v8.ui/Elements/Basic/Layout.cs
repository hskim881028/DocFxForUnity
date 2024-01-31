using Newtonsoft.Json;
using UnityEngine;
using V8.UI.Configuration;

namespace V8.UI.Elements.Basic
{
    public class Layout : Element
    {
        private CornerMode _cornerMode;
        private AxisMode _axisMode;
        private AlignmentMode _childAlignmentMode;
        private ConstraintMode _childConstraintMode;
        private Padding _padding;
        private Vector2 _childSize;
        private Vector2 _spacing;
        private int _childConstraintCount;

        [JsonConstructor]
        protected Layout(string id, string type) : base(id, type)
        {
        }
        
        public CornerMode CornerMode
        {
            get => _cornerMode;
            set => SetProperty(ref _cornerMode, value, nameof(CornerMode));
        }

        public AxisMode AxisMode
        {
            get => _axisMode;
            set => SetProperty(ref _axisMode, value, nameof(AxisMode));
        }

        public AlignmentMode ChildAlignmentMode
        {
            get => _childAlignmentMode;
            set => SetProperty(ref _childAlignmentMode, value, nameof(ChildAlignmentMode));
        }

        public ConstraintMode ChildConstraintMode
        {
            get => _childConstraintMode;
            set => SetProperty(ref _childConstraintMode, value, nameof(ChildConstraintMode));
        }

        public Padding Padding
        {
            get => _padding;
            set => SetProperty(ref _padding, value, nameof(Padding));
        }

        public Vector2 ChildSize
        {
            get => _childSize;
            set => SetProperty(ref _childSize, value, nameof(ChildSize));
        }

        public Vector2 Spacing
        {
            get => _spacing;
            set => SetProperty(ref _spacing, value, nameof(Spacing));
        }

        public int ChildConstraintCount
        {
            get => _childConstraintCount;
            set => SetProperty(ref _childConstraintCount, value, nameof(ChildConstraintCount));
        }
    }
}