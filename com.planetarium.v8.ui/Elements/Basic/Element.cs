using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using UnityEngine;
using V8.UI.Configuration;

namespace V8.UI.Elements.Basic
{
    public class Element : INotifyPropertyChanged, IDisposable
    {
        private AlignmentMode _anchorAlignmentMode;

        private SizeMode _sizeMode;
        private Vector2 _size;

        private PositionMode _positionMode;
        private Vector2 _position;

        public List<Element> Children { get; private set; }

        [JsonConstructor]
        protected Element(string id, string type, List<Element> children = null)
        {
            Id = id;
            Type = type;
            Children = children ?? new List<Element>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Id { get; }
        public string Type { get; }

        public AlignmentMode AnchorAlignmentMode
        {
            get => _anchorAlignmentMode;
            set => SetProperty(ref _anchorAlignmentMode, value, nameof(AnchorAlignmentMode));
        }

        public SizeMode SizeMode
        {
            get => _sizeMode;
            set => SetProperty(ref _sizeMode, value, nameof(SizeMode));
        }

        public Vector2 Size
        {
            get => _size;
            set => SetProperty(ref _size, value, nameof(Size));
        }

        public PositionMode PositionMode
        {
            get => _positionMode;
            set => SetProperty(ref _positionMode, value, nameof(PositionMode));
        }

        public Vector2 Position
        {
            get => _position;
            set => SetProperty(ref _position, value, nameof(Position));
        }
        
        public T GetElementInChildren<T>() where T : Element
        {
            foreach (var child in Children)
            {
                if (child is T element)
                {
                    return element;
                }

                var childElement = child.GetElementInChildren<T>();
                if (childElement != null)
                {
                    return childElement;
                }
            }

            return null;
        }
        
        public List<T> GetElementsInChildren<T>() where T : Element
        {
            var elements = new List<T>();
            foreach (var child in Children)
            {
                if (child is T element)
                {
                    elements.Add(element);
                }

                elements.AddRange(child.GetElementsInChildren<T>());
            }

            return elements;
        }
        public void Dispose()
        {
            PropertyChanged = null;
        }
        
        protected void SetProperty<T>(ref T field, T value, string propertyName)
        {
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return;
            }

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}