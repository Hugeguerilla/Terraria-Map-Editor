﻿using System;
using BCCL.Geometry.Primitives;
using BCCL.MvvmLight;

namespace TEditXna.Editor
{
    public class BrushSettings : ObservableObject
    {
        private int _maxOutline = 10;
        private int _maxHeight = 200;
        private int _maxWidth = 200;
        private int _minHeight = 2;
        private int _minWidth = 2;
        private int _outline = 1;

        private int _width = 20;
        private int _height = 20;

        private int _offsetX = 10;
        private int _offsetY = 10;
        private bool _isLocked = true;
        private bool _isOutline = false;
        private BrushShape _shape = BrushShape.Square;

        public event EventHandler BrushChanged;

        protected virtual void OnBrushChanged(object sender, EventArgs e)
        {
            if (BrushChanged != null) BrushChanged(sender, e);
        }

        private void BrushChange()
        {
            OnBrushChanged(this, new EventArgs());
        }


        public int MaxWidth { get { return _maxWidth; } }
        public int MaxHeight { get { return _maxHeight; } }
        public int MinWidth { get { return _minWidth; } }
        public int MinHeight { get { return _minHeight; } }

        public BrushShape Shape
        {
            get { return _shape; }
            set
            {
                Set("Shape", ref _shape, value);
                BrushChange();
            }
        }

        public int MaxOutline
        {
            get { return _maxOutline; }
            private set { Set("MaxOutline", ref _maxOutline, value); }
        }

        public bool IsOutline
        {
            get { return _isOutline; }
            set { Set("IsOutline", ref _isOutline, value); }
        }

        public bool IsLocked
        {
            get { return _isLocked; }
            set { Set("IsLocked", ref _isLocked, value); }
        }

        public int OffsetY
        {
            get { return _offsetY; }
            set { Set("OffsetY", ref _offsetY, value); }
        }

        public int OffsetX
        {
            get { return _offsetX; }
            set { Set("OffsetX", ref _offsetX, value); }
        }

        public int Height
        {
            get { return _height; }
            set
            {
                Set("Height", ref _height, value);
                if (IsLocked)
                {
                    _width = Height;
                    RaisePropertyChanged("Width");
                    OffsetX = _width / 2;
                }
                MaxOutline = Math.Min(Height, Width) / 2;
                OffsetY = _height / 2;
                BrushChange();
            }
        }

        public int Width
        {
            get { return _width; }
            set
            {
                Set("Width", ref _width, value);
                if (IsLocked)
                {
                    _height = Width;
                    RaisePropertyChanged("Height");
                    OffsetY = _height / 2;
                }
                MaxOutline = Math.Min(Height, Width) / 2;
                OffsetX = _width / 2;
                BrushChange();
            }
        }

        public int Outline
        {
            get { return _outline; }
            set { Set("Outline", ref _outline, value); }
        }
    }
}